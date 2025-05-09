using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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
    public void Save_Name(string name)
    {
        Debug.Log(name);
        current_name = name;
        score += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SaveScore(int HighScore)
    {
        SaveData data = new SaveData();
        data.TopPerson = current_name;
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
        DontDestroyOnLoad(gameObject);
        LoadScore();
        text.text = leader + ":" + score;
    }
    void Start_Game(string name)
    {
        current_name = name;
        Debug.Log(name);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Game_End(int points)
    {
        if (score < points)
        {

            SaveScore(points);
        }
    }
}
