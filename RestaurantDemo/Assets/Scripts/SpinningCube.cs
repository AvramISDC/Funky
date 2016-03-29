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
        if (Cube.transform.position.x < 223 || Cube.transform.position.x > 733)
            hSpeed = -hSpeed;
        if (Cube.transform.position.y < 182 || Cube.transform.position.y > 644)
            vSpeed = -vSpeed;

        Cube.transform.Rotate(0.2f, 0.3f, 0.6f);
        Cube.transform.Translate(hSpeed, vSpeed, 0, Space.World);
    }
}
