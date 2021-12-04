using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class XmlSerialization
{
    public static void Serialize<T>(string path, T objecto)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, objecto);
        writer.Close();
    }

    public static T Deserialize<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T objecto = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return objecto;
    }
}
