using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System;
using System.Collections.Generic;

[System.Serializable]

public class CommentItem
{
    public string UserID;
    public string Comment;
    public int Ratings;
}

public class Comments : MonoBehaviour
{
    public GameObject SubmitButton;
    public int RestaurantID;
    public GameObject GameController;

    public List<CommentItem> commentList;

    public GameObject CommentTemplate;

    public Transform contentPanel;
    private List<GameObject> commentsSpace = new List<GameObject>();

    public IEnumerator Start()
    {
        RestaurantID = SceneParameters.SelectedRestaurantId;
        if (RestaurantID != 0)
        {
            string url = "http://localhost:53313/api/Comments?RestaurantID=" + SceneParameters.SelectedRestaurantId;
            WWW request = new WWW(url);
            yield return request;
            if (request.error == null)
            {
                JsonData resultJson = JsonMapper.ToObject(request.text);
                for (int i = 0; i < resultJson.Count; i++)
                {
                    CommentItem comment = new CommentItem();
                    comment.Comment = resultJson[i]["Text"].ToString();
                    comment.Ratings = Convert.ToInt32(resultJson[i]["Ratings"].ToString());
                    GameController.GetComponent<ReceiveUser>().ReturnUsername(resultJson[i]["UserId"].ToString(), comment);
                    yield return comment.UserID;
                    commentList.Add(comment);
                }
            }
            else
            {
                Debug.Log(request.error);
            }
            PopulateList();
        }
    }

    public void PopulateList()
    {
        foreach (var commentSpace in commentsSpace)
        {
            Destroy(commentSpace);
        }
        commentsSpace.Clear();

        foreach (var comment in commentList)
        {
            GameObject newComment = Instantiate(CommentTemplate) as GameObject;
            CommentStorage commentSpace = newComment.GetComponent<CommentStorage>();
            commentSpace.commentTx.text = comment.Comment;
            commentSpace.Rating.text = comment.Ratings.ToString();
            commentSpace.whoMadeTheComment.text = comment.UserID;
            commentSpace.transform.SetParent(contentPanel);
            commentsSpace.Add(newComment);
        }
    }
}
