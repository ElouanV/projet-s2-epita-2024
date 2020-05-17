using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;
//Author : Elouan

public static class SaveSystem
{
    public static void SavePlayer(Player player, AudioMixer audioMixer)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player/currentSave.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerData data = new PlayerData(player, audioMixer);

        formatter.Serialize(stream,data);
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player/currentSave.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData result = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return result;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
