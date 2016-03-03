using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.Collections.Generic;

[System.Serializable]

public class CommentItem
{
    public string UserID;
    public string Comment;
    public string Ratings;
}

public class Comments : MonoBehaviour {

    public int RestaurantID;

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
                    comment.Ratings = resultJson[i]["Ratings"].ToString();
                    comment.UserID = resultJson[i]["UserId"].ToString();
                    commentList.Add(comment);
                }
            }
            else
            {
                Debug.Log(request.error);
            }
            foreach (var thing in commentList)
            {
                Debug.Log(thing.Comment + " " + thing.Ratings + " " + thing.UserID);
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
            commentSpace.Rating.text = comment.Ratings;
            commentSpace.whoMadeTheComment.text = comment.UserID;
            commentSpace.transform.SetParent(contentPanel);
            commentsSpace.Add(newComment);
        }
    }
}
