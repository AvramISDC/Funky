using UnityEngine;
using System.Collections;

public class Reserve : MonoBehaviour {



    public IEnumerator MakeReservation ()
    {
        WWWForm r = new WWWForm();
        r.AddField("dateandtime", SceneParameters.Selecteddatetime.ToString());
        r.AddField("UserId", SceneParameters.SelectedUserId);
        r.AddField("RestaurantId",SceneParameters.SelectedRestaurantId);

        r.headers["Content-Type"] = "application/x-www-form-urlencoded";
        WWW aaa = new WWW("http://localhost:53313/api/MakeReservation", r);
        yield return aaa;
        if (!string.IsNullOrEmpty(aaa.error))
        {
            Debug.Log(aaa.error);
        }

    }
    public void OnClick()
    {
        StartCoroutine (MakeReservation());
    }

}
