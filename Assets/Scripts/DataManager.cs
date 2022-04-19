using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string topPlayerName, playerName;
    public int highestScore = -1;
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }    
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
        LoadPlayerName();
    }

    [System.Serializable]
    class SaveBest
    {
        public string topPlayerName;
        public int highestScore;
    }

    [System.Serializable]
    class SavePlayer
    {
        public string playerName;
    }

    public void SaveBestScore()
    {
        SaveBest data = new SaveBest();
        data.topPlayerName = topPlayerName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savebest.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savebest.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveBest data = JsonUtility.FromJson<SaveBest>(json);

            topPlayerName = data.topPlayerName;
            highestScore = data.highestScore;
        }
    }

    public void SavePlayerName()
    {
        SavePlayer data = new SavePlayer();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveplayer.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/saveplayer.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);

            SavePlayer data = JsonUtility.FromJson<SavePlayer>(json);
            playerName = data.playerName;
        }
    }
}
