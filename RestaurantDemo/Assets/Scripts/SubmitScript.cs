using UnityEngine;
using System.Collections;

public class SubmitScript : MonoBehaviour {

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

    public void Check ()
    {
        Debug.Log(username + "," + password + "," + email);
    }
}
