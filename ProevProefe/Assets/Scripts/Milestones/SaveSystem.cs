
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(MileStoneData data, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/" + path;
        FileStream stream = new FileStream(path, FileMode.Create);

        MilestoneDataSave dataSave = new MilestoneDataSave(data);

        formatter.Serialize(stream, data);
        stream.Close();
            
    }

    public static MilestoneDataSave loadData(string path)
    {
        string filePath = Application.persistentDataPath + "/" + path;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

          MilestoneDataSave save = formatter.Deserialize(stream) as MilestoneDataSave;
            stream.Close(); 
            return save;
        }
        else
        {
            Debug.LogError("Save file not found" + path);
            return null;
        }
    }

}
