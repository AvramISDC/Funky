using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.Collections.Generic;

[System.Serializable]

public class RestaurantStart : MonoBehaviour {
    
    public Text RestaurantName;
    public Text RestaurantAdress;
    public Text RestaurantDescription;
    public Text RestaurantRating;
    public int RestaurantID;

    public IEnumerator Start ()
    {
        string url = "http://localhost:53313/api/Restaurants?ID=" + SceneParameters.SelectedRestaurantId;
        WWW request = new WWW(url);
        yield return request;
        if (request.error == null)
        {
            JsonData resultJson = JsonMapper.ToObject(request.text);
            RestaurantName.text = resultJson[0]["Name"].ToString();
            RestaurantRating.text = resultJson[0]["AverageStars"].ToString();
            RestaurantAdress.text = resultJson[0]["Adress"].ToString();
            RestaurantDescription.text = resultJson[0]["Description"].ToString();
        }
        else
        {
            Debug.Log(request.error);
        }
        RestaurantID = SceneParameters.SelectedRestaurantId;
    }
}