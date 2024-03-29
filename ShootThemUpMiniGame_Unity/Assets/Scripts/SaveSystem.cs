using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveSystem 
{
   public static void SaveGame(GameController gc) 
   {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(GameController.gameController);
        formatter.Serialize(stream, data);
        stream.Close();
   }
    public static PlayerData LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else 
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
