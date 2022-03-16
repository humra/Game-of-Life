using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float cameraSpeed = 1f;
    [SerializeField]
    private float zoomSpeed = 50f;

    private Vector3 movementVector = Vector3.zero;

    private void Update()
    {
        movementVector = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movementVector.y += cameraSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            movementVector.y += cameraSpeed * Time.deltaTime * -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movementVector.x += cameraSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            movementVector.x += cameraSpeed * Time.deltaTime * -1;
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            movementVector.z += zoomSpeed * Time.deltaTime;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            movementVector.z += zoomSpeed * Time.deltaTime * -1;
        }

        mainCamera.transform.position += movementVector;
    }
}
