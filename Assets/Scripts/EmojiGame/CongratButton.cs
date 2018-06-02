using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratButton : MonoBehaviour {

    public GameObject congratulations;
    public Animator a;
	// Use this for initialization
	void Start () {
        congratulations.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        congratulations.SetActive(false);
    }
}
