using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform transf;
    private Vector3 offset;
    public bool isInverted = false;
    private int inverted;
    public GameObject player;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (InvertedYMode)
            isInverted = true;
        transf = GetComponent<Transform>();
        offset = transf.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
        {
            inverted = -1;
        }
        else {
            inverted = 1;
        }
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * speed, Vector3.left) * offset;
        transf.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
