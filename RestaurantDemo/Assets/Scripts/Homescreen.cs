using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;
using System;

public class Homescreen : MonoBehaviour
{

    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 0f;
    private int fadeDir = 1;
    private bool fadestarted = false;

    public void OnGUI()
    {
        if (fadestarted == false)
        {
            return;
        }
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
        if (fadeDir == 1 && alpha == 1)
        {
            Application.LoadLevel(0);
        }
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

    public void OnClick()
    {
        fadestarted = true;
    }

    IEnumerator Start ()
    {
        string url = "http://localhost:53313/Api/Restaurants";
        WWW fa = new WWW(url);
        yield return fa;
        if(fa.error == null)
        {
            ProcessRestaurants(fa.text);
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
    public void RestaurantClick(int ID)
    {
        Debug.Log("Click" + ID);
        
    }

}
