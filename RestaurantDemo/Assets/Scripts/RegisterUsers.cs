using UnityEngine;
using System.Collections;

public class RegisterUsers : MonoBehaviour {

    static IEnumerator RegisterUser ()
    {
        WWWForm p = new WWWForm();
        p.AddField("username", "test");
        p.AddField("password", "test");
        p.AddField("emailadress", "testadd.com");

        p.headers["Content-Type"] = "application/x-www-form-urlencoded"; ;

        WWW www = new WWW("http://localhost:53313/api/Users", p);
        yield return www;
        Debug.Log(www.error);
    }


    public void OnClick()
    {
        StartCoroutine(RegisterUser());
    }

}
