﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Flagrum.Archiver.Binmod;
using Flagrum.Gfxbin.Btex;
using Flagrum.Gfxbin.Gmdl;
using Flagrum.Gfxbin.Gmdl.Constructs;
using Flagrum.Gfxbin.Gmdl.Templates;
using Flagrum.Gfxbin.Gmtl;
using Newtonsoft.Json;

namespace Flagrum.Console;

public static class InteropTests
{
    public static void Test()
    {
        var jsonPath = "C:\\Users\\Kieran\\Desktop\\Mods\\Noctis3\\noctis_custom_2.ffxvbinmod.json";
        var json = File.ReadAllText(jsonPath);
        var gpubin = JsonConvert.DeserializeObject<Gpubin>(json);

        var builder = new BinmodBuilder("Noctis Custom 2", "noctis_custom_2", "main",
            "de81d8a4-53d8-4ca9-bcf0-f9397e82db81", Boye.Noctis);
        var gameAssets = new List<string>();

        foreach (var mesh in gpubin.Meshes)
        {
            foreach (var (textureId, filePath) in mesh.Material.Textures)
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    if (MaterialBuilder.DefaultTextures.TryGetValue(textureId, out var replacement))
                    {
                        mesh.Material.TextureData.Add(new TextureData
                        {
                            Id = textureId,
                            Uri = $"data://mod/{builder.ModDirectoryName}/sourceimages/{replacement}",
                            Data = MaterialBuilder.GetDefaultTextureData(replacement)
                        });
                    }
                }
                else
                {
                    var tempPath = Path.GetTempFileName();
                    BtexConverter.Convert(filePath, tempPath,
                        textureId.ToLower().Contains("normal")
                            ? BtexConverter.TextureType.Normal
                            : BtexConverter.TextureType.Color);

                    // TODO: See if there's a way to detect when the command finishes rather than sleep an arbitrary duration
                    Thread.Sleep(100);
                    var btexData = File.ReadAllBytes(tempPath);
                    File.Delete(tempPath);
                    var fileName = filePath.Split('/', '\\').Last();
                    var extension = fileName.Split('.').Last();
                    var btexFileName = fileName.Replace($".{extension}", ".btex");
                    var uri = $"data://mod/{builder.ModDirectoryName}/sourceimages/{btexFileName}";

                    mesh.Material.TextureData.Add(new TextureData
                    {
                        Id = textureId,
                        Uri = uri,
                        Data = btexData
                    });
                }
            }

            var material = MaterialBuilder.FromTemplate(
                mesh.Material.Id,
                $"{mesh.Name.ToLower()}_mat",
                builder.ModDirectoryName,
                mesh.Material.Inputs.Select(p => new MaterialInputData
                {
                    Name = p.Key,
                    Values = p.Value
                }).ToList(),
                mesh.Material.TextureData.Select(p => new MaterialTextureData
                {
                    Name = p.Id,
                    Path = p.Uri
                }).ToList());

            var materialWriter = new MaterialWriter(material);

            builder.AddFile(material.Uri, materialWriter.Write());

            foreach (var texture in mesh.Material.TextureData)
            {
                builder.AddFile(texture.Uri, texture.Data);
            }

            // TODO: Update the EARC file puller to operate quicker
            // One improvement may be to only read the data for the files we need
            gameAssets.AddRange(material.ShaderBinaries.Select(s => s.Path));
            gameAssets.AddRange(material.Textures
                .Where(t => !t.Path.StartsWith("data://mod"))
                .Select(t => t.Path));
        }

        var model = OutfitTemplate.Build(builder.ModDirectoryName, builder.ModelName, gpubin);
        var replacer = new ModelReplacer(model, gpubin);
        model = replacer.Replace();
        var writer = new ModelWriter(model);
        var (gfxData, gpuData) = writer.Write();
        builder.AddModel(builder.ModelName, gfxData, gpuData);

        builder.AddGameAssets(gameAssets.Distinct());
        builder.WriteToFile("C:\\Testing\\de81d8a4-53d8-4ca9-bcf0-f9397e82db81.ffxvbinmod");
    }

    // public static void Export()
    // {
    //     var jsonPath = "C:\\Users\\Kieran\\Desktop\\Mods\\Noctis3\\noctis_custom_2.ffxvbinmod.json";
    //     var json = File.ReadAllText(jsonPath);
    //     var gpubin = JsonConvert.DeserializeObject<Gpubin>(json);
    //     //File.Delete(jsonPath);
    //
    //     var exportPath = jsonPath.Replace(".json", "");
    //     var gameAssets = new List<string>();
    //
    //     var modName = jsonPath.Split('/', '\\').Last().Split('.')[0];
    //     var builder = new BinmodBuilder(modName, "de81d8a4-53d8-4ca9-bcf0-f9397e82db81");
    //
    //     foreach (var mesh in gpubin.Meshes)
    //     {
    //         foreach (var (textureId, filePath) in mesh.Material.Textures)
    //         {
    //             if (string.IsNullOrEmpty(filePath))
    //             {
    //                 continue;    
    //             }
    //             
    //             var tempPath = Path.GetTempFileName();
    //             BtexConverter.Convert(filePath, tempPath,
    //                 textureId.ToLower().Contains("normal")
    //                     ? BtexConverter.TextureType.Normal
    //                     : BtexConverter.TextureType.Color);
    //             Thread.Sleep(100);
    //             var btexData = File.ReadAllBytes(tempPath);
    //             File.Delete(tempPath);
    //             var fileName = filePath.Split('/', '\\').Last();
    //             var extension = fileName.Split('.').Last();
    //             var btexFileName = fileName.Replace($".{extension}", ".btex");
    //             var uri = $"data://mod/{modName}/{btexFileName}";
    //
    //             mesh.Material.TextureData.Add(new TextureData
    //             {
    //                 Id = textureId,
    //                 Uri = uri,
    //                 Data = btexData
    //             });
    //         }
    //
    //         var material = MaterialBuilder.FromTemplate(
    //             mesh.Material.Id,
    //             mesh.Name,
    //             $"data://mod/{modName}/materials/{mesh.Name}.gmtl.gfxbin",
    //             mesh.Material.Inputs.Select(p => new MaterialInputData
    //             {
    //                 Name = p.Key,
    //                 Values = p.Value
    //             }).ToList(),
    //             mesh.Material.TextureData.Select(p => new MaterialTextureData
    //             {
    //                 Name = p.Id,
    //                 Path = p.Uri
    //             }).ToList());
    //
    //         var materialWriter = new MaterialWriter(material);
    //         builder.AddMaterial(material.Name, materialWriter.Write());
    //
    //         foreach (var texture in mesh.Material.TextureData)
    //         {
    //             builder.AddFile(texture.Uri, texture.Data);
    //         }
    //
    //         gameAssets.AddRange(material.ShaderBinaries.Select(s => s.Path));
    //         gameAssets.AddRange(material.Textures
    //             .Where(t => !t.Path.StartsWith("data://mod"))
    //             .Select(t => t.Path));
    //     }
    //
    //     var model = OutfitTemplate.Build(exportPath, gpubin);
    //     var replacer = new ModelReplacer(model, gpubin);
    //     model = replacer.Replace();
    //     var writer = new ModelWriter(model);
    //     var (gfxData, gpuData) = writer.Write();
    //
    //     builder.AddModel(model.Name, gfxData, gpuData);
    //     builder.AddGameAssets(gameAssets.Distinct());
    //     builder.WriteToFile("C:\\Testing\\de81d8a4-53d8-4ca9-bcf0-f9397e82db81.ffxvbinmod");
    // }
}