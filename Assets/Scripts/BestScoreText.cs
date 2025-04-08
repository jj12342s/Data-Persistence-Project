using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;



public class BestScoreText : MonoBehaviour
{
    public Text text;
    public string leader;
    public int score;
    public string current_name;
    [System.Serializable]
    class SaveData
    {
        public string TopPerson;
        public int HighScore;
    }
    public void SaveScore(string TopPerson, int HighScore)
    {
        SaveData data = new SaveData();
        data.TopPerson = TopPerson;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            leader = data.TopPerson;
            score = data.HighScore;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        text.text = leader + ":" + score;
    }
    void Start_Game(string name)
    {
        current_name = name;
        //go to next scene and make this object not die between scenes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
