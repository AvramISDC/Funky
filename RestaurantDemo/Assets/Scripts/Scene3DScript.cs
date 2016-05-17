using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene3DScript : MonoBehaviour {

    public void GoBack()
    {
        SceneManager.LoadScene(3);
    }
}
