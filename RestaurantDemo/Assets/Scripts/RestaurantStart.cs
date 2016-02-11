using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RestaurantStart : MonoBehaviour {
    
    public Text RestaurantNumber;
    public void Start ()
    {
        RestaurantNumber.text = SceneParameters.SelectedRestaurantId.ToString();


	}
}
