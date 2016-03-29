using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System;
using System.Collections.Generic;
public class ReceiveUser : MonoBehaviour {

    public void ReturnUsername(string id,CommentItem comentItem)
    {
        StartCoroutine(ReceiveUsername(id, comentItem));
    }

    public IEnumerator ReceiveUsername(string UserID, CommentItem comentItem)
    {
        WWW www = new WWW("http://localhost:53313/api/UserGet/" + UserID + "?Username=default");
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            JsonData resultJson = JsonMapper.ToObject(www.text);
            comentItem.UserID = resultJson[0]["Username"].ToString();
            yield break;
        }
    }
}
