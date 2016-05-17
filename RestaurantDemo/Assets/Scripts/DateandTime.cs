using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DateandTime : MonoBehaviour {

    public Dropdown date;
    public Dropdown time;
   // public static ArrayList<DateTime>dates  

	void Start () {
        for (int i = 0; i < 14; i++)
        {
            date.options.Add(new Dropdown.OptionData(DateTime.Now.Date.AddDays(i).ToLongDateString()));

        }
        for (int i = 0; i < 24; i++)
        {
            time.options.Add(new Dropdown.OptionData(string.Format("{0}:00", i)));

        }



	
	}
	
	
}
