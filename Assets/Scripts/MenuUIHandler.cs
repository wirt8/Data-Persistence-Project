using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerNameInput;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerNameInput.text = DataManager.Instance.playerName;
        UpdateBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void EnterPlayerName()
    {
        string input = playerNameInput.textComponent.text;
        
        if (input != DataManager.Instance.playerName) {
            DataManager.Instance.playerName = input;
            DataManager.Instance.SavePlayerName();
        }
    }

    public void UpdateBestScore()
    {
        string path = Application.persistentDataPath + "/savebest.json";
        if (File.Exists(path)) {
            bestScoreText.text = "Best Score : " + DataManager.Instance.topPlayerName + " : " + DataManager.Instance.highestScore; 
        } else {
            bestScoreText.text = "Best Score";
        }
    }
}
