using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class Item
{
    public string name;
    public double averagestars;
}

public class CreateScrollList : MonoBehaviour {

    public GameObject sampleButton;
    public List<Item> itemList;

    void Start()
    {
        PopulateList ();
    }

    void PopulateList ()
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate (sampleButton) as GameObject;
        }
    }
	
}
