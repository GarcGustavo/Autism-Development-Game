using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

    public EmojiGameManager manager;

    void Start()
    {
        manager = FindObjectOfType<EmojiGameManager>();
    }

    public void ButtonType()
    {
        manager.choiceType = gameObject.name;
    }
}
