using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System;
using System.Collections.Generic;
public class ReceiveUser : MonoBehaviour {

    public string Username;

    public string ReturnUsername(string TemporaryUserId)
    {
        StartCoroutine(ReceiveUsername(TemporaryUserId));
        return Username;
    }

    public IEnumerator ReceiveUsername(string UserID)
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
            Username = resultJson[0]["Username"].ToString();
            yield return Username;
        }
    }
}
