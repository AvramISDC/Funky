using UnityEngine;
using System.Collections;

public class Homescreen : MonoBehaviour
{

    public void BackToLogginScreen()
    {
        Application.LoadLevel(0);
    }
    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
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
        if (fadeDir == -1 && alpha == 0)
        {
            Application.LoadLevel(1);
        }

    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

}
