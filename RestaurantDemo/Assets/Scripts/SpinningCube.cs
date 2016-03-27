using UnityEngine;
using System.Collections;

public class SpinningCube : MonoBehaviour {

    public GameObject Cube;

    public float vSpeed = -0.5f;
    public float hSpeed = -0.5f;

    void Start ()
    {
	
        
	}
	
	
	void Update ()
    {
        Cube.transform.Rotate(0.2f, 0.3f, 0.6f);
        Cube.transform.Translate(vSpeed, hSpeed, 0, Space.World);
	}
}
