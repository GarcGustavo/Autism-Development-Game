using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextOnClick : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager textBox;
    
    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        textBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && !textBox.stopPlayerInput)
        {
            textBox.ReloadScript(theText);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
