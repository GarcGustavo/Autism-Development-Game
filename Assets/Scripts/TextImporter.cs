using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerController player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<PlayerController>();

        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));

        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
