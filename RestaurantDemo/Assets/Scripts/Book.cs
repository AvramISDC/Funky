using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{

    public Dropdown Date;
    public Dropdown Time;
    public Text Available;
    private static int date = -1;
    private static int time = -1;
    public Button bookbutton;


    public void DateChanged(int newdate)
    {
        date = Date.value;
        //StartCoroutine(CheckReservation());
    }
    public void TimeChanged(int newtime)
    {
        time = Time.value;
        //StartCoroutine(CheckReservation());
    }

    public IEnumerator CheckReservation()
    {
        if (time == -1 || date == -1)
            yield break;

        string url = "http://localhost:53313/api/Reservations";
        string Querry = "";

        Querry = Querry + "RestaurantID=" + SceneParameters.SelectedRestaurantId;
        Querry = Querry + "&UserID=" + SceneParameters.SelectedUserId;


        DateTime dateandtime = DateTime.Today.AddDays(date).AddHours(time);
        SceneParameters.Selecteddatetime = dateandtime;

        Querry = Querry + "&DateandTime=" + dateandtime.ToString("MM/dd/yyyy");

        if (Querry != "")
        {
            url = url + "?" + Querry;
        }
        WWW book = new WWW(url);
        yield return book;
        if (book.error == null)
        {
            bool result = bool.Parse(book.text);
            if (result == false)
            {
                bookbutton.enabled = true;
                Available.text = "Available";
            }
            else
            {
                bookbutton.enabled = false;
                Available.text = "Not Available";
            }
        }
        else
        {
            Debug.Log(book.error);
        }
    }

    public void Changed()
    {
        this.StartCoroutine(CheckReservation());


    }


}
