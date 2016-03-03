using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;
using System;
using UnityEngine.SceneManagement;

public class Homescreen : MonoBehaviour
{

    public Texture2D fadeoutTexture;
    public float fadeSpeed = 1.4f;
    //private int drawDepth = -1000;
    //private float alpha = 0f;
    private int fadeDir = 1;
    private bool fadestarted = false;
    

    //public void OnGUI()
    //{
    //    if (fadestarted == false)
    //    {
    //        return;
    //    }
    //    alpha += fadeDir * fadeSpeed * Time.deltaTime;
    //    alpha = Mathf.Clamp01(alpha);
    //    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
    //    GUI.depth = drawDepth;
    //    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
    //    if (fadeDir == 1 && alpha == 1)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

    public void OnClick()
    {
        //fadestarted = true;
        SceneManager.LoadScene(0);
    }

    IEnumerator Start ()
    {
        return GetRestaurants(saveratings, saveadress);
    }

    public static string saveadress ="";
    public static int saveratings = -1;


    public void GetRestaurantsWithFilter(int Rating = -1, string Adress = "")
    {
        saveadress = Adress;
        saveratings = Rating;
        StartCoroutine(GetRestaurants(Rating, Adress));
    }

    private IEnumerator GetRestaurants(int Rating = -1, string Adress = "")
    {
        string url = "http://localhost:53313/Api/Restaurants";
        string Querry = "";
        if(Rating != -1)
        {
            Querry = Querry + "Ratings=" + Rating;
        }
        if(Adress != "")
        {
            if(Querry != "")
            {
                Querry = Querry + "&";
            }
            Querry = Querry + "Adress=" + Adress;
        }
        if (Querry != "")
            url = url + "?" + Querry;

        WWW fa = new WWW(url);
        yield return fa;
        if (fa.error == null)
        {
            ProcessRestaurants(fa.text);
        }
        else
        {
            Debug.Log(fa.error);
        }
    }

    private void ProcessRestaurants(string Json)
    {
        var Game = GameObject.Find("GameController").GetComponent<CreateScrolList>();
        Game.itemList.Clear();
        JsonData json = JsonMapper.ToObject(Json);
        Iitem r;
        for (int i = 0; i < json.Count; i++)
        {
            r = new Iitem();
            r.name = json[i]["Name"].ToString();
            r.averagestars = json[i]["AverageStars"].ToString();
            r.thingToDo = new Button.ButtonClickedEvent();
            var ID = Convert.ToInt32(json[i]["Id"].ToString());
            r.thingToDo.AddListener(() =>RestaurantClick(ID));
            Game.itemList.Add(r);
        }
        Game.PopulateList();
    }
    public SampleButtonPageOpener _SampleButtonPageOpener;
    public void RestaurantClick(int ID)
    {
        SceneParameters.SelectedRestaurantId = ID;
        _SampleButtonPageOpener.OnClick();
    }
}   
