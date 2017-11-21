using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public string startGame;
    public string levelSelect;
    public string settings;

    public void StartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void Settings()
    {
        SceneManager.LoadScene(settings);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }

}
