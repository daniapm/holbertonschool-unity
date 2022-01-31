using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    public float speedH;
    public float speedV;

    float mouseX;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        // Initial position of Camera controller
        // Calculate and store the offset value by getting the distance
        // between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        // offset(x,y,z) stored => -1, 24.8, -9
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fixed the Camera position
        transform.position = player.transform.position + offset ;
        mouseX += speedH * Input.GetAxis("Mouse X");
        mouseY += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(mouseY, mouseX, 0.0f);


    }
}
