using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VisitButton : MonoBehaviour {

	public void OnClick () {
        SceneManager.LoadScene(4);
    }
}
