using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensibility = 90.0f;
    public Transform playerBody;
    float xRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MouseView();
    }

    void MouseView()
    {
        float mouseXAxis = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseYAxis = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        xRotation -= mouseYAxis;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseXAxis);
    }
}
