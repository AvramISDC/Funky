using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class Iitem
{
    public string name;
    public string averagestars;
    public Button.ButtonClickedEvent thingToDo;
}

public class CreateScrolList : MonoBehaviour
{

    public GameObject sampleButton;
    public List<Iitem> itemList;

    public Transform contentPanel;

    void Start()
    {
        PopulateList();
    }

    public void PopulateList()
    {
        foreach (var item in itemList)
        {
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            SampleButton button = newButton.GetComponent<SampleButton>();
            button.nameoftherestaurant.text = item.name;
            button.averagestars.text = item.averagestars;
            button.button.onClick = item.thingToDo;
            newButton.transform.SetParent(contentPanel);
        }
    }
}