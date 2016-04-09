using UnityEngine;
using System.Collections;

public class CollectInfo : MonoBehaviour {

    public int UserID;
    public int RestaurantID;

    void Start()
    {
        UserID = SubmitComment.UserId;
        RestaurantID = SceneParameters.SelectedRestaurantId;
    }
}
