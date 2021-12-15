﻿using System.Text;

namespace Flagrum.Core.Archive.Binmod;

public static class Modmeta
{
    public static byte[] Build(Binmod mod)
    {
        var type = (BinmodType)mod.Type;

        return type switch
        {
            BinmodType.Cloth => BuildOutfit(mod),
            BinmodType.StyleEdit => BuildMultiOutfit(mod),
            BinmodType.Character => BuildModelReplacement(mod),
            BinmodType.Weapon or BinmodType.Multi_Weapon => BuildWeapon(mod),
            _ => null
        };
    }

    private static byte[] BuildWeapon(Binmod mod)
    {
        var builder = new StringBuilder();
        builder.AppendLine("[meta]");
        builder.AppendLine($"modtype={BinmodTypeHelper.GetModmetaTypeName(mod.Type)}");
        builder.AppendLine($"type={BinmodTypeHelper.GetModmetaTargetName(mod.Type, mod.Target)}");

        if (mod.Model2Name == null)
        {
            builder.AppendLine($"modify_gmdl[0]=mod/{mod.ModDirectoryName}/{mod.ModelName}.gmdl");
        }
        else
        {
            builder.AppendLine($"modify_gmdl[0]=mod/{mod.ModDirectoryName}/{mod.Model1Name}.gmdl");
            builder.AppendLine($"modify_gmdl[1]=mod/{mod.ModDirectoryName}/{mod.Model2Name}.gmdl");
        }

        builder.AppendLine($"name={mod.GameMenuTitle}");
        builder.AppendLine("help=");
        builder.AppendLine($"title={mod.WorkshopTitle}");
        builder.AppendLine($"desc={mod.Description?.Replace("\r\n", "\\n")?.Replace("\n", "\\n")}");
        builder.AppendLine($"uuid={mod.Uuid}");
        builder.AppendLine($"itemid={mod.ItemId}");
        builder.AppendLine($"ischecked={(mod.IsWorkshopMod ? "True" : "False")}");
        builder.AppendLine($"isapplytogame={(mod.IsApplyToGame ? "True" : "False")}");
        builder.AppendLine($"itemplace={(mod.IsWorkshopMod ? "E_SteamWorkshop" : "E_Local")}");
        builder.AppendLine($"attack={mod.Attack}");
        builder.AppendLine($"hp_max={mod.MaxHp}");
        builder.AppendLine($"mp_max={mod.MaxMp}");
        builder.AppendLine($"critical={mod.Critical}");
        builder.AppendLine($"strength={mod.Strength}");
        builder.AppendLine($"vitality={mod.Vitality}");
        builder.AppendLine($"magic={mod.Magic}");
        builder.AppendLine($"spirit={mod.Spirit}");
        builder.AppendLine($"bullet={mod.Ballistic}");
        builder.AppendLine($"fire={mod.Fire}");
        builder.AppendLine($"ice={mod.Ice}");
        builder.AppendLine($"thunder={mod.Thunder}");
        builder.AppendLine($"dark={mod.Dark}");
        return Encoding.UTF8.GetBytes(builder.ToString());
    }

    private static byte[] BuildModelReplacement(Binmod mod)
    {
        var builder = new StringBuilder();
        builder.AppendLine("[meta]");
        builder.AppendLine($"modtype={BinmodTypeHelper.GetModmetaTypeName(mod.Type)}");

        for (var i = 0; i < mod.OriginalGmdls.Count; i++)
        {
            builder.AppendLine($"origin_gmdl[{i}]={mod.OriginalGmdls[i]}");
        }

        builder.AppendLine($"modify_gmdl[0]=mod/{mod.ModDirectoryName}/{mod.ModelName}.gmdl");
        builder.AppendLine($"count_original_gmdls={mod.OriginalGmdls.Count}");
        builder.AppendLine($"type={BinmodTypeHelper.GetModmetaTargetName(mod.Type, mod.Target)}");
        builder.AppendLine($"title={mod.WorkshopTitle}");
        builder.AppendLine($"desc={mod.Description?.Replace("\r\n", "\\n")?.Replace("\n", "\\n")}");
        builder.AppendLine($"uuid={mod.Uuid}");
        builder.AppendLine($"itemid={mod.ItemId}");
        builder.AppendLine($"ischecked={(mod.IsWorkshopMod ? "True" : "False")}");
        builder.AppendLine($"isapplytogame={(mod.IsApplyToGame ? "True" : "False")}");
        builder.AppendLine($"itemplace={(mod.IsWorkshopMod ? "E_SteamWorkshop" : "E_Local")}");
        return Encoding.UTF8.GetBytes(builder.ToString());
    }

    private static byte[] BuildMultiOutfit(Binmod mod)
    {
        var builder = new StringBuilder();
        builder.AppendLine("[meta]");
        builder.AppendLine($"modtype={BinmodTypeHelper.GetModmetaTypeName(mod.Type)}");
        builder.AppendLine($"type={BinmodTypeHelper.GetModmetaTargetName(mod.Type, mod.Target)}");
        builder.AppendLine("thumbnail1=default.png");
        builder.AppendLine("thumbnail2=default.png");

        if (mod.Model2Name == null)
        {
            builder.AppendLine($"gmdl1={mod.ModelName}.gmdl");
        }
        else
        {
            builder.AppendLine($"gmdl1={mod.Model1Name}.gmdl");
            builder.AppendLine($"gmdl2={mod.Model2Name}.gmdl");
        }

        builder.AppendLine($"title={mod.WorkshopTitle}");
        builder.AppendLine($"desc={mod.Description?.Replace("\r\n", "\\n")?.Replace("\n", "\\n")}");
        builder.AppendLine($"uuid={mod.Uuid}");
        builder.AppendLine($"itemid={mod.ItemId}");
        builder.AppendLine($"ischecked={(mod.IsWorkshopMod ? "True" : "False")}");
        builder.AppendLine($"isapplytogame={(mod.IsApplyToGame ? "True" : "False")}");
        builder.AppendLine($"itemplace={(mod.IsWorkshopMod ? "E_SteamWorkshop" : "E_Local")}");
        builder.AppendLine($"name={mod.GameMenuTitle}");
        builder.AppendLine($"gender={mod.Gender}");
        return Encoding.UTF8.GetBytes(builder.ToString());
    }

    private static byte[] BuildOutfit(Binmod mod)
    {
        var builder = new StringBuilder();
        builder.AppendLine("[meta]");
        builder.AppendLine($"modtype={BinmodTypeHelper.GetModmetaTypeName(mod.Type)}");
        builder.AppendLine($"title={mod.WorkshopTitle}");
        // Can't append literal newlines to the modmeta or things will break
        builder.AppendLine($"desc={mod.Description?.Replace("\r\n", "\\n")?.Replace("\n", "\\n")}");
        builder.AppendLine($"uuid={mod.Uuid}");
        builder.AppendLine($"type={BinmodTypeHelper.GetModmetaTargetName(mod.Type, mod.Target)}");
        builder.AppendLine($"itemid={mod.ItemId}");
        builder.AppendLine($"ischecked={(mod.IsWorkshopMod ? "True" : "False")}");
        builder.AppendLine($"isapplytogame={(mod.IsApplyToGame ? "True" : "False")}");
        builder.AppendLine($"itemplace={(mod.IsWorkshopMod ? "E_SteamWorkshop" : "E_Local")}");
        builder.AppendLine($"modify_gmdl[0]=mod/{mod.ModDirectoryName}/{mod.ModelName}.gmdl");
        builder.AppendLine($"name={mod.GameMenuTitle}");
        builder.AppendLine("help=");
        builder.AppendLine($"strength={mod.Strength}");
        builder.AppendLine($"vitality={mod.Vitality}");
        builder.AppendLine($"magic={mod.Magic}");
        builder.AppendLine($"spirit={mod.Spirit}");
        builder.AppendLine($"hp_max={mod.MaxHp}");
        builder.AppendLine($"mp_max={mod.MaxMp}");
        builder.AppendLine($"bullet={mod.Ballistic}");
        builder.AppendLine($"fire={mod.Fire}");
        builder.AppendLine($"ice={mod.Ice}");
        builder.AppendLine($"thunder={mod.Thunder}");
        builder.AppendLine($"dark={mod.Dark}");
        return Encoding.UTF8.GetBytes(builder.ToString());
    }
}