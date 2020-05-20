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
        // Create path to %userprofile%\AppData\Local\Packages\<productname>\LocalState.
        string path = Application.persistentDataPath + "/player/player_save.kamelquest";
        // Create file strea
        FileStream stream = new FileStream(path,FileMode.Create);
        // Use the constructor of player data with player and audioMixer in parameter.
        PlayerData data = new PlayerData(player, audioMixer);
        // Formate data in binary and write it on the file stream
        formatter.Serialize(stream,data);
        // Then close the file stream
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        // Get the path and load data only if file exist
        string path = Application.persistentDataPath + "/player/player_save.kameelquest";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // Create file stream
            FileStream stream = new FileStream(path, FileMode.Open);
            // Convert binary file to PlayerData
            PlayerData result = formatter.Deserialize(stream) as PlayerData;
            //Then close the file stream
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
