﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Button buttonPrefab;
    public GameObject textBoxPrefab;
    public List<GameObject> characters;

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

    public void SpawnButton() { }
    public void CreateChoice() { }
    public void ChangePlayerState(string state) { }
    public void ChangeSceneState(string state) { }

}
