﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Flagrum.Core.Utilities;
using Flagrum.Gfxbin.Gmtl.Data;
using Newtonsoft.Json;

namespace Flagrum.Gfxbin.Gmtl;

public static class MaterialBuilder
{
    public static Dictionary<string, string> DefaultTextures = new()
    {
        {"BaseColor0_Texture", "white-color.btex"},
        {"BaseColor0Texture", "white-color.btex"},
        {"BaseColorRedEye_Texture", "black.btex"},
        {"Occlusion0_Texture", "white.btex"},
        {"Occlusion0Texture", "white.btex"},
        {"MRS0_Texture", "teal.btex"},
        {"Texture0", "white.btex"},
        {"SSSMask_Texture", "white.btex"},
        {"OpacityMask0_Texture", "white.btex"},
        {"Transparency0_Texture", "white.btex"},
        {"Transparency0Texture", "white.btex"},
        {"Emissive0_Texture", "black.btex"},
        {"EmissiveColor0Texture", "black.btex"},
        {"EmissiveRedEye_Texture", "black.btex"},
        {"RefractionMask0", "white.btex"},
        {"Normal0_Texture", "blue.btex"},
        {"Normal0InnerTexture", "blue.btex"},
        {"Normal0Texture", "blue.btex"},
        {"BaseColor1_Texture", "white-color.btex"},
        {"BaseColor1_Texture0", "white-color.btex"},
        {"BaseColor2_Texture", "white-color.btex"},
        {"BloodTexture_Mask", "white.btex"},
        {"DirtField_mask", "white.btex"},
        {"DirtTexture_Mask", "white.btex"},
        {"DropsMask_Texture", "white.btex"},
        {"DustColorMaskTex", "white.btex"},
        {"Emissive1_Texture", "black.btex"},
        {"Emissive2_Texture", "black.btex"},
        {"Emissive3_Texture", "black.btex"},
        {"FazzMask0_Texture", "white.btex"},
        {"IceMask_Texture", "white.btex"},
        {"MuliMask_Texture_Detail", "black.btex"},
        {"MultiMask_Texture_Lip", "black.btex"},
        {"MultiMask_Texture_Manicure", "black.btex"},
        {"MultiMask_Texture_wrinkle", "black.btex"},
        {"MultiMask_Texture1", "black.btex"},
        {"MultiMask_Texture10", "black.btex"},
        {"MultiMask_Texture11", "black.btex"},
        {"MultiMask_Texture12", "black.btex"},
        {"MultiMask_Texture13", "black.btex"},
        {"MultiMask_Texture14", "black.btex"},
        {"MultiMask_Texture15", "black.btex"},
        {"MultiMask_Texture16", "black.btex"},
        {"MultiMask_Texture2", "black.btex"},
        {"MultiMask_Texture3", "black.btex"},
        {"MultiMask_Texture4", "black.btex"},
        {"MultiMask_Texture5", "black.btex"},
        {"MultiMask_Texture6", "black.btex"},
        {"MultiMask_Texture7", "black.btex"},
        {"MultiMask_Texture8", "black.btex"},
        {"MultiMask_Texture9", "black.btex"},
        {"MultiMask0_Texture", "black.btex"},
        {"MultiMask0_Texture0", "black.btex"},
        {"MultiMask1_Texture", "black.btex"},
        {"MultiMask2_Texture", "black.btex"},
        {"MultiMask3_Texture", "black.btex"},
        {"MultiMask3_Texture0", "black.btex"},
        {"MultiMask4_Texture", "black.btex"},
        {"MultiMaskRedEye_Texture", "black.btex"},
        {"Normal_Texture_Detail", "blue.btex"},
        {"Normal_Texture_wrinkle", "blue.btex"},
        {"Normal1_Texture", "blue.btex"},
        {"Normal1_Texture0", "blue.btex"},
        {"Normal2_Texture", "blue.btex"},
        {"Occlusion_Texture_Detail", "white.btex"},
        {"Occlusion1_Texture", "white.btex"},
        {"OpacityMask1_Texture", "white.btex"},
        {"StoneMask_Texture", "white.btex"},
        {"SweatTexture_Mask", "white.btex"},
        {"wipersMask_Texture", "white.btex"}
    };

    public static Material FromTemplate(string templateName, string materialName, string modDirectoryName,
        List<MaterialInputData> inputs,
        List<MaterialTextureData> textures)
    {
        var templatePath = $"{IOHelper.GetExecutingDirectory()}\\Gmtl\\Templates\\{templateName}.json";
        var json = File.ReadAllText(templatePath);
        var material = JsonConvert.DeserializeObject<Material>(json);

        material.Name = materialName;
        material.Uri = $"data://mod/{modDirectoryName}/materials/{materialName}.gmtl";
        material.NameHash = (uint)Cryptography.Hash(material.Uri);

        foreach (var input in inputs)
        {
            SetInputValues(material, input.Name, input.Values);
        }

        foreach (var texture in textures)
        {
            SetTexturePath(material, texture.Name, texture.Path);
        }

        return material;
    }

    private static void SetInputValues(Material material, string inputName, params float[] values)
    {
        var match = material.InterfaceInputs.FirstOrDefault(u =>
            u.ShaderGenName.ToLower() == inputName.ToLower() && u.InterfaceIndex == 0);

        if (match == null)
        {
            throw new ArgumentException($"Input {inputName} was not found in material {material.Name}.",
                nameof(inputName));
        }

        match.Values = values;
    }

    private static void SetTexturePath(Material material, string name, string path)
    {
        var match = material.Textures.FirstOrDefault(t => t.ShaderGenName == name);

        if (match == null)
        {
            throw new ArgumentException($"Texture {name} was not found in material {material.Name}", nameof(name));
        }

        var dependencyMatch = material.Header.Dependencies.FirstOrDefault(d => d.Path == match.Path);

        match.Path = path;

        // TODO: Rework material editor to generate dependency tables and remove this fallable idiocy
        if (dependencyMatch == null)
        {
            return;
        }

        dependencyMatch.Path = path;
    }

    public static byte[] GetDefaultTextureData(string name)
    {
        return File.ReadAllBytes($"{IOHelper.GetExecutingDirectory()}\\Gmtl\\Textures\\{name}");
    }
}

public class MaterialInputData
{
    public string Name { get; set; }
    public float[] Values { get; set; }
}

public class MaterialTextureData
{
    public string Name { get; set; }
    public string Path { get; set; }
}