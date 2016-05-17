using UnityEngine;
using System.Collections;

public class RegisterUsers : MonoBehaviour {

    private string username;
    private string password;
    private string email;

    public void GetUsername(string usernameInput)
    {
        username = usernameInput;
    }
    public void GetPassword(string passwordInput)
    {
        password = passwordInput;
    }
    public void GetEmail(string emailInput)
    {
        email = emailInput;
    }

    public IEnumerator RegisterUser ()
    {
        WWWForm p = new WWWForm();
        p.AddField("username", username);
        p.AddField("password", password);
        p.AddField("emailadress", email);

        p.headers["Content-Type"] = "application/x-www-form-urlencoded"; ;

        WWW www = new WWW("http://localhost:53313/api/Users", p);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
    }

    public void OnClick()
    {
        StartCoroutine(RegisterUser());
    }

}
