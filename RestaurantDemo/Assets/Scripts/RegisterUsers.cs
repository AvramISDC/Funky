using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.UI;


public class RegisterUsers : MonoBehaviour {

    private string username;
    private string password;
    private string email;
    public Text Message;

    public void GetUsername(string usernameInput)
    {
        username = usernameInput;
    }
    public void GetPassword(string passwordInput)
    {
        password = passwordInput;
    }

    public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    public void GetEmail(string emailInput)
    {
        if (IsEmail(emailInput))
        {
            email = emailInput;
        }
        else
        {
            Message.text = "Invalid email";
        }
    }

    public static bool IsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
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
            Message.text = "There is an error with our server";
        }
        else
        {
            Message.text = "Your account has been created";
        }
    }

    public void OnClick()
    {
        StartCoroutine(RegisterUser());
    }

}
