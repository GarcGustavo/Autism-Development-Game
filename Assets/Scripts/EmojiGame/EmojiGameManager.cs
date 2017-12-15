using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiGameManager : MonoBehaviour
{

    public int playerScore;
    public int gamePhase;
    public int maxButtons;

    public string choiceType;
    public string questionType;
    public string answerType;

    public bool validQuestion;
    public bool activeTurn;

    public Transform controlPanel;
    public Sprite[] buttonImages;
    public List<Button> buttons;
    public Button buttonPrefab;
    public List<string> spawnedButtons;

    public GameObject questionBox;
    public Sprite[] questionImages;
    public List<string> usedQuestions;
    public Image question;

    // Use this for initialization
    void Start()
    {
        activeTurn = false;
        playerScore = 0;
        gamePhase = 1;
        validQuestion = false;
        question = questionBox.GetComponent<Image>();
        createButtons();
    }

    // Update is called once per frame
    // 1 = emoji buttons phase, 2 = face buttons, 3 = text question w/ hybrid buttons
    void Update()
    {
        if (playerScore < 300)
            gamePhase = 1;
        else if (playerScore < 600)
            gamePhase = 2;
        else if (playerScore >= 600)
            gamePhase = 3;
    }

    //currently spawns random buttons appropriate for each phase, does not guarantee a single correct answer, also spawns 1 less than max to make room for correct answer
    //The while loops thing is dirty hack cause I'm sleep deprived if you're reading this and it's still there I'm sorry
    //all that's left here is to spawn the correct button choice using the answerType var I made earlier and defined in createQuestions
    private void TurnUpdate()
    {
        if (!activeTurn)
        {
            if (gamePhase == 1)
            {
                //SpawnButton();
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(0, 4)].name;
                    while (spawnedButtons.Contains(newButtonName))
                    {
                        newButtonName = buttonImages[Random.Range(4, 9)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else if (gamePhase == 2)
            {
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(5, 9)].name;
                    while (spawnedButtons.Contains(newButtonName))
                    {
                        newButtonName = buttonImages[Random.Range(5, 9)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else if (gamePhase == 3)
            {
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(0, 9)].name;
                    while (spawnedButtons.Contains(newButtonName))
                    {
                        newButtonName = buttonImages[Random.Range(0, 9)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else
                Debug.Log("No valid game phase detected!");
            activeTurn = true;
        }
    }

    //Shuffles and places the answer buttons on the control panel randomly
    private void shuffleButtons()
    {

    }

    //creates a question randomly depending on phase and avoids repeating past questions
    //theres some weird stuff going on here, take a look later when not sleep deprived
    private void createQuestion()
    {
        //creates questions depending on phase, image array 0-4 are emojis, 5-9 faces
        while (!validQuestion)
        {
            if (gamePhase == 1)
            {
                question.sprite = questionImages[Random.Range(0, questionImages.Length - 5)];
            }
            else if (gamePhase == 2)
            {
                question.sprite = questionImages[Random.Range(5, questionImages.Length)];
            }
            else
            {
                question.sprite = questionImages[Random.Range(0, questionImages.Length)];
            }

            questionType = question.sprite.name;

            //This is disgusting and I'm ashamed but I need a quick working demo
            //find a better way to deal with answer checking later
            switch (questionType)
            {
                case "Emoji_Angry":
                    answerType = "Face_Angry";
                    break;
                case "Emoji_Happy":
                    answerType = "Face_Happy";
                    break;
                case "Emoji_Sad":
                    answerType = "Face_Sad";
                    break;
                case "Emoji_Scared":
                    answerType = "Face_Scared";
                    break;
                case "Emoji_Shocked":
                    answerType = "Face_Shocked";
                    break;
                case "Face_Angry":
                    answerType = "Emoji_Angry";
                    break;
                case "Face_Happy":
                    answerType = "Emoji_Happy";
                    break;
                case "Face_Sad":
                    answerType = "Emoji_Sad";
                    break;
                case "Face_Scared":
                    answerType = "Emoji_Scared";
                    break;
                case "Face_Shocked":
                    answerType = "Emoji_Shocked";
                    break;
                default:
                    answerType = "none";
                    Debug.Log("No valid question type detected!");
                    break;
            }

            //should rewrite, ugly and redundant
            if (usedQuestions.Contains(questionType) && gamePhase != 3)
            {
                validQuestion = false;
            }
            else
                validQuestion = true;
        }
        //adds the valid question type to a list of used questions to avoid repeating questions
        usedQuestions.Add(questionType);
    }

    private void createButtons()
    {
        //spawns a list of buttons containing each possible button type
        for (int i = 0; i < buttonImages.Length; i++)
        {
            Button newButton = GameObject.Instantiate(buttonPrefab);
            newButton.transform.SetParent(controlPanel);
            newButton.image.sprite = buttonImages[i];
            newButton.name = buttonImages[i].name;
            //spawns the buttons at the center of the controls panel
            newButton.transform.SetPositionAndRotation(controlPanel.position, controlPanel.rotation);
            buttons.Add(newButton);
            //should create invisible list of buttons when set to false
            newButton.gameObject.SetActive(true);
        }
    }

    private void SpawnButton(string name)
    {
        if (name == "all")
        {
            for (int i = 0; i < buttons.Capacity; i++)
            {
                buttons[i].gameObject.SetActive(true);
                spawnedButtons.Add(buttons[i].gameObject.name);
            }
        }
        for (int i = 0; i < buttons.Capacity; i++)
        {
            if (name == buttons[i].name)
            {
                buttons[i].gameObject.SetActive(true);
                spawnedButtons.Add(buttons[i].gameObject.name);
            }
        }
    }

    private void deleteButton(string name)
    {
        if (name == "all")
        {
            for (int i = 0; i < buttons.Capacity; i++)
            {
                buttons[i].gameObject.SetActive(false);
                spawnedButtons.Remove(buttons[i].gameObject.name);
            }
        }
        for (int i = 0; i < buttons.Capacity; i++)
        {
            if (name == buttons[i].name)
            {
                buttons[i].gameObject.SetActive(false);
                spawnedButtons.Remove(buttons[i].gameObject.name);
            }
                
        }
    }

    public void createTextBox()
    {

    }

}
