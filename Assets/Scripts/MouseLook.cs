using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public float minimumX = 45.0f;
    public float maximumX = 90.0f;
    public float minimumY = -45.0f;
    public float maximumY = 45.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY += mouseX;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
