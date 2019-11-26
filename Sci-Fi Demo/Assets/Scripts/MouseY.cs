using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    public float Ysensitivity = 1.0f;


    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x += mouseY * Ysensitivity*-1;
        transform.localEulerAngles = newRotation;
    }
}
