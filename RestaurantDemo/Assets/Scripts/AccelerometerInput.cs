using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour
{

    void Update()
    {
        float speed = 2;
        float xInput = Input.acceleration.x;
        float yInput = Input.acceleration.y;
        //float zInput = Input.acceleration.z;
        if(yInput >= 0.1)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
        if (yInput <= -0.08)
        {
            transform.Translate(0, 0, -Time.deltaTime * speed);
        }
        if (xInput >= 0.08)
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        if (xInput <= -0.08)
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
        //if (zInput >= 0.1 || xInput >= 0.1 || yInput >= 0.1)
        //{
        //    transform.Translate(0, 0, yInput);
        //    transform.Translate(xInput, 0, 0);
        //}
        //transform.Translate(0, y, 0);
        //transform.Rotate(0, yInput, zInput);
    }
}