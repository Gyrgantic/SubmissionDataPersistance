using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username;
    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string Username;
        public int Score;
    }

    public void CompareRecords()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData Record = JsonUtility.FromJson<SaveData>(json);

            if (Score > Record.Score)
            {
                SaveRecord();
            }
        }
        else SaveRecord();
    }

    public void SaveRecord()
    {
        SaveData Record = new SaveData();
        Record.Username = Username;
        Record.Score = Score;

        string json = JsonUtility.ToJson(Record);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public string GetRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        string json = File.ReadAllText(path);
        SaveData Record = JsonUtility.FromJson<SaveData>(json);

        return "Best Score: " + Record.Username + " : " + Record.Score;
    }

}
