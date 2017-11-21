using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public string startMenu;
    public string level1;
    public string level2;
    public string level3;
    public string level4;

    public void StartMenu()
    {
        SceneManager.LoadScene(startMenu);
    }

    public void Level1()
    {
        SceneManager.LoadScene(level1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(level2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(level3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(level4);
    }

}
