using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Instance of the class
    public static GameManager Instance;

    //variable storing the name
    public string playerName;

    //variable storing the highest score
    public int highestScore;

    //variable storing the name of the player with highest score
    public string highestPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // Awake is called as soon as the object is created
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // This code enables you to access the GameManager object from any other script.  
        DontDestroyOnLoad(gameObject);

        //We load the previous best score
        LoadScorePlayer();
    }


    [System.Serializable]
    class SaveData
    {
        //variable storing the highest score
        public int highestScore;

        //variable storing the name of the player with highest score
        public string highestPlayer;
    }


    public void SaveScorePlayer()
    {
        //Create a new instance of the save data 
        SaveData data = new SaveData();
        data.highestScore = GameManager.Instance.highestScore;
        data.highestPlayer = GameManager.Instance.highestPlayer;

        //Transformed that instance to JSON with JsonUtility.ToJson:
        string saved_json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", saved_json);
    }


    public void LoadScorePlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        //Check if a .json file exists.
        if (File.Exists(path))
        {
            string load_json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(load_json);

            //We set the highest score and player
            highestPlayer = data.highestPlayer;
            highestScore = data.highestScore;
        }
    }
}
