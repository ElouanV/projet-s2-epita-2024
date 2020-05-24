using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;
//Author : Elouan
/// <summary>
/// The main <c>SaveSystem</c> class.
/// Contains all methods to save player's data and load it.
/// <para> Data are saves in a binary file called player_save.kamelquest </para>
/// <list type="bullet">
/// <item>
/// <term>SavePlayer</term>
/// <description>Use to save data by writting on the binary file</description>
/// </item>
/// <item>
/// <term>LoadPlayer</term>
/// <description>Use to load data on our player, convert the binary file in data in PlayerData class</description>
/// </item>
/// </list>
/// </summary>
public static class SaveSystem
{
    ///<summary>
    ///<para> This function is used to save data of the player in a  binary file </para>
    ///<para> 
    ///<param Name = "player"> is the player which we need to save datas</param>
    ///<param Name = "audioMixer"> is the mixer which we want to save settings</param>
    ///<remakrs> This function use BinaryFormatter(), which convert data to a binary file, which is harder to understand than a simple JSON file or an XML file. So it's safer.</remarks>
    ///<return> This function return nothing, it's just write on the binary file </return>
    ///</summary>
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        // Create path to %userprofile%\AppData\Local\Packages\<productname>\LocalState for Windows.
        string path = Application.persistentDataPath + "/player_save.kq";
        // Create file stream
        FileStream stream = new FileStream(path,FileMode.Create);
        // Use the constructor of player data with player and audioMixer in parameter.
        PlayerData data = new PlayerData(player);
        // Formate data in binary and write it on the file stream
        formatter.Serialize(stream,data);
        // Then close the file stream
        stream.Close();
    }

    ///<summary>
    ///<para> This function is used to load data of the player</para>
    ///<remakrs> This function use BinaryFormatter(), which convert binary file to data, which is harder to understand than a simple JSON file or an XML file. So it's safer.</remarks>
    ///<return> This function return an object of the class PlayerData which contain all datas loaded</return>
    ///</summary>
    public static PlayerData LoadPlayer()
    {
        // Get the path and load data only if file exist
        string path = Application.persistentDataPath + "/player_save.kq";
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
