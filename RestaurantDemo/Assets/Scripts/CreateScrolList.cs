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
    private List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        var b = GameObject.Find("SearchBox").GetComponent<InputField>();
        b.text = SearchBoxText;
        PopulateList();
    }

    public void PopulateList()
    {
        FilterRestaurants(SearchBoxText);
    }

    private static string SearchBoxText = "";


    public void FilterRestaurants(string SearchText)
    {
        SearchBoxText = SearchText;
        foreach (var button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();

        foreach (var item in itemList)
        {
            if (item.name.ToLower().StartsWith(SearchText.ToLower()) == false)
                continue;
            GameObject newButton = Instantiate(sampleButton) as GameObject;
            SampleButton button = newButton.GetComponent<SampleButton>();
            button.nameoftherestaurant.text = item.name;
            button.averagestars.text = item.averagestars;
            button.button.onClick = item.thingToDo;
            newButton.transform.SetParent(contentPanel);
            buttons.Add(newButton);
        }

    }
}