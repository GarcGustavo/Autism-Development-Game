using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject[] items;

    public void ActivateItem(int i)
    {
        items[i].SetActive(true);
    }

    public void DeActivateItem(int i)
    {
        items[i].SetActive(false);
    }

    // Use this for initialization
    void Start () {
        DeActivateItem(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
