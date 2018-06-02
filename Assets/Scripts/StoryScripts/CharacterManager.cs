using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public Sprite[] emotionState;
    public string charState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (charState == "happy")
            GetComponent<SpriteRenderer>().sprite = emotionState[3];
        else if (charState == "sad")
            GetComponent<SpriteRenderer>().sprite = emotionState[1];
        else
            GetComponent<SpriteRenderer>().sprite = emotionState[0];
    }

    public void ChangeCharState(string state)
    {
        charState = state;
    }
}
