using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public GameObject Invalid;
    public static string username;
    private string password;

    public void GetUsername(string usernameInput)
    {
        username = usernameInput;
    }
    public void GetPassword(string passwordInput)
    {
        password = passwordInput;
    }

    public Texture2D fadeoutTexture;
    public float fadeSpeed = 1.4f;

    private int drawDepth = -1000;
    private float alpha = 0f;
    private int fadeDir = 1;
    private bool fadestarted = false;


    public void OnGUI ()
    {
        if (fadestarted == false)
        {
            return;
        }
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture ( new Rect (0, 0, Screen.width, Screen.height), fadeoutTexture );
        if (fadeDir == 1 && alpha == 1)
        {
            SceneManager.LoadScene(1);
        }

    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed; 
    }
    public void OnClick()
    {
        StartCoroutine(LoginUser());
    }
    public void LoadScene()
    {
        fadestarted = true;
    }

    public IEnumerator LoginUser()
    {
        username = !string.IsNullOrEmpty(username) ? username : "";
        password = !string.IsNullOrEmpty(password) ? password : "";
        WWWForm q = new WWWForm();
        q.AddField("username", username);
        q.AddField("password", password);

        q.headers["Content-Type"] = "application/x-www-form-urlencoded"; ;

        WWW www = new WWW("http://localhost:53313/api/Login", q);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.text == "true")
            {
                fadestarted = true;
            }
            else
            {
                Invalid.SetActive(true);
            }
        }
    }
}
