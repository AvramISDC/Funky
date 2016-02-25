using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SampleButtonPageOpener : MonoBehaviour {


    public Texture2D fadeoutTexture;
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 0f;
    private int fadeDir = 1;
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
        if (fadeDir == 1 && alpha == 1)
        {
            SceneManager.LoadScene(3);
        }
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return fadeSpeed;
    }

    public void OnClick()
    {
        fadestarted = true;
    }
}

public static class SceneParameters {

    public static int SelectedRestaurantId = 0;
}
