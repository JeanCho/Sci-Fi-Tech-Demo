using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseX : MonoBehaviour
{
    
    public float Xsensitivity = 1.0f;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * Xsensitivity;
        transform.localEulerAngles = newRotation;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,
        //    transform.localEulerAngles.y+( mouseX*Xsensitivity),
        //    transform.localEulerAngles.z );
    }
}
