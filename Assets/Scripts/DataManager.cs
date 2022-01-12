using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string lastUserName;
    public string highScoreUser;
    public int highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    class DataClass
    {
        public string lastUserName;
        public string highScoreUser;
        public int highScore;
    }

    public void SaveData()
    {
        DataClass data = new DataClass();
        data.lastUserName = lastUserName;
        data.highScoreUser = highScoreUser;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            DataClass data = JsonUtility.FromJson<DataClass>(json);

            lastUserName = data.lastUserName;
            highScoreUser = data.highScoreUser;
            highScore = data.highScore;

            Debug.Log("Data loaded: user=" + lastUserName + ", highscore=" + highScoreUser + ":" + highScore);
        }
    }
}
