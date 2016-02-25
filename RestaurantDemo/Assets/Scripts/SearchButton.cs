using UnityEngine;
using System.Collections;

public class SearchButton : MonoBehaviour {

    private string Adress = "";
    private int Rating = -1;

    public void RatingsChanged(int newrating)
    {
        this.Rating = newrating;
    }

    public void AdressChanged (string newadress)
    {
        this.Adress = newadress;
    }

    public void OnClick()
    {
        var h = GameObject.Find("BackButton").GetComponent<Homescreen>();
        h.GetRestaurantsWithFilter(this.Rating, this.Adress);
    }
}
