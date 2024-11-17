using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;
using static Define;

public static class CsvToJsonConverter
{
    private const string CsvFolderPath = "/@Resources/Data/Csv/";
    private const string JsonFolderPath = "/@Resources/Data/Json/";

    private const string CsvName = "Table.csv";
    private const string JsonName = "Table.json";

#if UNITY_EDITOR
    [MenuItem("Tools/ParseExcel %#K")]
    public static void ParseExcel()
    {
        //ParseCreatureData("Creature");

        Debug.Log("Complete DataTransformer");
    }

    
    //static void ParseCreatureData(string filename)
    //{
    //    CreatureDataLoader loader = new CreatureDataLoader();

    //    #region ExcelData
    //    string[] lines = File.ReadAllText($"{Application.dataPath}{CsvFolderPath}{filename}{CsvName}").Split("\n");

    //    for (int y = 1; y < lines.Length; y++)
    //    {
    //        string[] row = lines[y].Replace("\r", "").Split(',');

    //        if (row.Length == 0)
    //            continue;
    //        if (string.IsNullOrEmpty(row[0]))
    //            continue;

    //        int i = 0;
    //        CreatureData cd = new CreatureData();
    //        cd.dataId = ConvertValue<int>(row[i++]);
    //        cd.descriptionTextID = ConvertValue<string>(row[i++]);
    //        cd.prefabLabel = ConvertValue<string>(row[i++]);
            
    //        cd.maxHp = ConvertValue<float>(row[i++]);
    //        cd.upMaxHp = ConvertValue<float>(row[i++]);
            
    //        cd.atk = ConvertValue<float>(row[i++]);
    //        cd.upAtk = ConvertValue<float>(row[i++]);
            
    //        cd.def = ConvertValue<float>(row[i++]);
    //        cd.moveSpeed = ConvertValue<float>(row[i++]);
    //        cd.totalExp = ConvertValue<float>(row[i++]);
    //        cd.hpRate = ConvertValue<float>(row[i++]);
    //        cd.atkRate = ConvertValue<float>(row[i++]);
    //        cd.defRate = ConvertValue<float>(row[i++]);
    //        cd.moveSpeedRate = ConvertValue<float>(row[i++]);

    //        cd.animationLabels = ConvertList<string>(row[i++]);
    //        cd.iconLabel = ConvertValue<string>(row[i++]);
            
    //        cd.learnableSkill= ConvertList<int>(row[i++]);
    //        cd.defaultSkill = ConvertValue<int>(row[i++]);

    //        loader.creatures.Add(cd);
    //    }

    //    #endregion

    //    string jsonStr = JsonConvert.SerializeObject(loader, Formatting.Indented);
    //    File.WriteAllText($"{Application.dataPath}{JsonFolderPath}{filename}{JsonName}", jsonStr);
    //    AssetDatabase.Refresh();
    //}
    
    public static T ConvertValue<T>(string value)
    {
        if (string.IsNullOrEmpty(value))
            return default(T);

        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
        return (T)converter.ConvertFromString(value);
    }

    public static List<T> ConvertList<T>(string value)
    {
        if (string.IsNullOrEmpty(value))
            return new List<T>();

        return value.Split('|').Select(x => ConvertValue<T>(x)).ToList();
    }
#endif
}
