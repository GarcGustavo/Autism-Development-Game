using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    //dialogue manager logic code work-in-progress

    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject[] choices;
    public bool activateChoices;

    //Placeholder code for design
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

        sentences = new Queue<string>();

        //placeholder
        score = 0;
        playerState = "init";
        sceneState = "init";
        correctChoice = false;
        textBoxPrefab.SetActive(false);
        activateChoices = true;
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnButton(string name) {

        if (name == "all")
        {
            for (int i = 0; i < buttons.Length-1; i++)
            {
                buttons[i].gameObject.SetActive(true);
                //should switch this to a simple bool the button has to keep track
                //spawnedButtons.Add(buttons[i].gameObject.name);
            }
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if (name == buttons[i].name)
            {
                buttons[i].gameObject.SetActive(true);
                spawnedButtons[i] = buttons[i];
            }
        }

    }
    public void CreateChoice() { }
    public void ChangePlayerState(string state) { }

    public void ChangeSceneState(string state)
    {
        sceneState = state;
    }

    public void StartDialogue (Dialogue dialogue)
    {
        textBoxPrefab.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        textBoxPrefab.SetActive(false);
        if (activateChoices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].SetActive(true);
            }
            activateChoices = false;
        }
        Debug.Log("End of dialogue");
    }

}
