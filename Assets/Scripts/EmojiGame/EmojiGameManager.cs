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
        TurnUpdate();
    }
    
    //The while loops thing is dirty hack cause I'm sleep deprived, I'm sure there's a better and more efficient way
    //spawn the correct button choice using the answerType var I made earlier and defined in createQuestions
    private void TurnUpdate()
    {
        if (!activeTurn)
        {
            createQuestion();
            SpawnButton(answerType);
            if (gamePhase == 1)
            {
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(5, 10)].name;
                    while (spawnedButtons.Contains(newButtonName) || newButtonName == answerType)
                    {
                        newButtonName = buttonImages[Random.Range(5, 10)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else if (gamePhase == 2)
            {
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(0, 5)].name;
                    while (spawnedButtons.Contains(newButtonName) || newButtonName == answerType)
                    {
                        newButtonName = buttonImages[Random.Range(0, 5)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else if (gamePhase == 3)
            {
                for (int i = 0; i < maxButtons - 1; i++)
                {
                    string newButtonName = buttonImages[Random.Range(0, 10)].name;
                    while (spawnedButtons.Contains(newButtonName) || newButtonName == answerType)
                    {
                        newButtonName = buttonImages[Random.Range(0, 10)].name;
                    }
                    SpawnButton(newButtonName);
                }
            }
            else
                Debug.Log("No valid game phase detected!");
            shuffleButtons(spawnedButtons);
            activeTurn = true;
        }
        if (choiceType == answerType)
        {
            playerScore += 100;
            activeTurn = false;
            deleteButton("all");
            choiceType = "none";
            deleteQuestion();
            //activate a congratulatory animation here
        }
    }

    //Shuffles and places the answer buttons on the control panel randomly
    //need to reset position later, its done in deleteButtons() for now
    //the double for loop is innefficient have to remake it later, I'll have to refactor the way the buttons are handled later probably
    private void shuffleButtons(List<string> buttonsToShuffle)
    {
        List<string> buttonsDeck = new List<string>();
        //start by the amount of pixels you want to move the buttons, same amount is then added succesively
        int moveBy = -150;
        int offset = (-moveBy);

        //adds the buttons to the deck in a random order
        for (int i = 0; i < buttonsToShuffle.Count;i++)
        {
            string shuffleName = spawnedButtons[Random.Range(0, buttonsToShuffle.Count)];
            if (!buttonsDeck.Contains(shuffleName))
                buttonsDeck.Add(shuffleName);
            else
                i--;
        }

        for(int i = 0; i < buttonsDeck.Count; i++)
        {
            for (int j = 0; j < buttons.Count; j++)
            {
                if (buttonsDeck[i] == buttons[j].name)
                {
                    Vector3 newPos = controlPanel.position;
                    newPos.x += moveBy;
                    buttons[j].transform.SetPositionAndRotation(newPos, controlPanel.rotation);
                    moveBy = moveBy + offset;
                }
            }
        }
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
                //this should later be replaced with the text question variants, will also have to change how buttons and answertypes work for phase 3 choices
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
            //should create invisible list of buttons when set to false, set to true for testing purposes
            newButton.gameObject.SetActive(false);
        }
    }

    private void SpawnButton(string name)
    {
        if (name == "all")
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].gameObject.SetActive(true);
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

    private void deleteButton(string name)
    {
        if (name == "all")
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].gameObject.SetActive(false);
                spawnedButtons.Remove(buttons[i].gameObject.name);
                //resets the transform of the button to the center of the panel
                buttons[i].transform.SetPositionAndRotation(controlPanel.position, controlPanel.rotation);
            }
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            if (name == buttons[i].name)
            {
                buttons[i].gameObject.SetActive(false);
                spawnedButtons.Remove(buttons[i].gameObject.name);
                //resets the transform of the button to the center of the panel
                buttons[i].transform.SetPositionAndRotation(controlPanel.position, controlPanel.rotation);
            }
        }
    }

    private void deleteQuestion()
    {
        validQuestion = false;
        questionType = "none";
        answerType = "";
    }

    public void createTextBox()
    {

    }

}
