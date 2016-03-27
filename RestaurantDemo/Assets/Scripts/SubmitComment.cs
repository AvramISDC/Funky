using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using LitJson;

public class SubmitComment : MonoBehaviour {

    public string Username;
    public Slider Slider;
    public int Rating;
    public string CommentText;
    public static int UserId;
    public GameObject LoginButton;
    public GameObject GameController;
    public string InsideUsername;
    public Text ratingtext;

    void Start()
    {
        StartCoroutine(ReceiveUser(0,Login.username));
    }

    public void ReceiveRating () {
        Rating = Convert.ToInt32(Slider.value);
        ratingtext.text = Rating.ToString();
	}

    public void ReceiveComment(string ReceivedText)
    {
        CommentText = ReceivedText;
        Debug.Log(CommentText);
    }

    public IEnumerator ReceiveUser(int TemporaryUserId, string TemporaryUsername)
    {
        WWW www = new WWW("http://localhost:53313/api/UserGet/" + TemporaryUserId + "?Username=" + TemporaryUsername);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            JsonData resultJson = JsonMapper.ToObject(www.text);
            if (TemporaryUserId == 0)
            {
                UserId = Convert.ToInt32(resultJson[0]["Id"].ToString());
            }
            else
            {
                InsideUsername = resultJson[0]["Username"].ToString();
                Debug.Log(InsideUsername);
                //GameController.GetComponent<Comments>().SendMessage("RetriveUsername", InsideUsername);
            }
        }
    }

    //public string ReturnUsername(int TemporaryUserId, string TemporaryUsername)
    //{
    //    StartCoroutine(ReceiveUser(TemporaryUserId, TemporaryUsername));
    //    Debug.Log(InsideUsername);
    //    return InsideUsername;
    //}

    public void OnClick()
    {
        StartCoroutine(RegisterComment());
    }

    public IEnumerator RegisterComment()
    {
        WWWForm p = new WWWForm();
        p.AddField("CommentText", CommentText);
        p.AddField("Ratings", Rating);
        p.AddField("UserId", UserId);
        p.AddField("RestaurantID", SceneParameters.SelectedRestaurantId);


        p.headers["Content-Type"] = "application/x-www-form-urlencoded"; ;

        WWW www = new WWW("http://localhost:53313/api/PostComments", p);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("It worked");
        }

    }
}
