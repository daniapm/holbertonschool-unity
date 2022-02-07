using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scenes

public class CameraController : MonoBehaviour
{

    private Vector3 offset;
    private float speed = 10.0f;

    public Transform trackerPlayer;

    private void Start()
    {
        offset = transform.position - trackerPlayer.transform.position;
        
        transform.rotation = Quaternion.Euler(0, trackerPlayer.transform.rotation.x, 0);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        }
        
        transform.position = trackerPlayer.position + offset;
        
        transform.LookAt(trackerPlayer.position);
    }
}
