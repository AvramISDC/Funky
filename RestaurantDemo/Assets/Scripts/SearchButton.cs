using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchButton : MonoBehaviour {

    private static string Adress = "";
    private static int Rating = -1;
    public static int DropdownIndex = 0;
    public static string InputFieldText = "";

    public void RatingsChanged(int newrating)
    {
        Rating = newrating;
    }

    public void AdressChanged (string newadress)
    {
        Adress = newadress;
    }

    public void Start()
    {
        var Dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        Dropdown.value = DropdownIndex;
        var InputField = GameObject.Find("InputField").GetComponent<InputField>();
        InputField.text = InputFieldText;
    }

    public void OnClick()
    {
        var h = GameObject.Find("BackButton").GetComponent<Homescreen>();
        h.GetRestaurantsWithFilter(Rating,Adress);
        DropdownIndex = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        InputFieldText = GameObject.Find("InputField").GetComponent<InputField>().text;
        var Criteria = GameObject.Find("Criteria").GetComponent<CriteriaButton>();
        Criteria.OnClick();
    }
}
