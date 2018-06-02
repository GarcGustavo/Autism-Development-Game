using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Button buttonPrefab;
    public GameObject textBoxPrefab;
    public List<GameObject> characters;
    public Button[] buttons;
    //should add an isSpawned bool to button prefab instead of this array
    public Button[] spawnedButtons;

    public bool correctChoice;
    public int score;
    public string playerState;
    public string sceneState;

    public List<string> sceneStates;
    public List<Sprite> backGroundStates;
    public List<Sprite> characterStates;
    public List<string> dialogueStates;


    // Use this for initialization
    void Start () {
        score = 0;
        playerState = "init";
        sceneState = "init";
        correctChoice = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnButton(string name) {

        if (name == "all")
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].gameObject.SetActive(true);
                //should switch this to a simple bool the button has to keep track
                spawnedButtons.Add(buttons[i].gameObject.name);
            }
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            if (name == buttons[i].name)
            {
                buttons[i].gameObject.SetActive(true);
                spawnedButtons.Add(buttons[i].gameObject.name);
            }
        }

    }
    public void CreateChoice() { }
    public void ChangePlayerState(string state) { }
    public void ChangeSceneState(string state) { }

}
