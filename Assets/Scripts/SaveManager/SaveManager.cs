using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveManager
{
    //static string path = Application.persistentDataPath + "/av.dat";

    public static void Save(SaveData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/av.dat", FileMode.Create);

        Debug.Log("Saved");
        bf.Serialize(file, data);
        file.Close();
    }

    public static SaveData Load()
    {
        if (File.Exists(Application.persistentDataPath + "/av.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/av.dat", FileMode.Open);
            SaveData data = bf.Deserialize(file) as SaveData;
            Debug.Log("Loaded");

            file.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found");
        }
        return null;
    }
}
