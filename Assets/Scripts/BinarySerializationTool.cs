using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySerializationTool
{


    public static void Save<T>(T obj, string name)
    {
        
            FileStream SaveData = new FileStream(name, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(SaveData, obj);
            SaveData.Close();
        
        
    }
    public static void Load<T>(ref T obj, string name)
    {
        if (File.Exists(name))
        {
            FileStream SaveData = new FileStream(name, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            obj = (T)bf.Deserialize(SaveData);
            SaveData.Close();
        }
        else
        {
            File.Create(name);
        }
        
    }

}
