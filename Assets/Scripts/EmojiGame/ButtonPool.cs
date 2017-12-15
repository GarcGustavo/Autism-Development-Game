using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPool : MonoBehaviour {
    
    public GameObject buttonPrefab;
    private List<GameObject> inactiveInstances = new List<GameObject>();
    public GameObject controlPad;

    // Returns an instance of the prefab
    public GameObject GetObject()
    {
        GameObject spawnedButton;
        spawnedButton = (GameObject)GameObject.Instantiate(buttonPrefab);
        
        spawnedButton.transform.SetParent(controlPad.transform);
        spawnedButton.SetActive(true);
        
        return spawnedButton;
    }
    
    public void ReturnObject(GameObject toReturn)
    {
        if (toReturn != null)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);
            
            inactiveInstances.Add(toReturn);
        }
    }
}