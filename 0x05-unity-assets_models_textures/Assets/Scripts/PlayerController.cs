using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Handles player control</summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController pc;
    private Transform p2;
    public Transform cam;
    private Vector3 moveYou = Vector3.zero;
    public float speed = 10f;
    public float jump = 15f;
    private float vert;

    void Awake()
    {
        pc = GetComponent<CharacterController>();
        p2 = GetComponent<Transform>();
    }

    void Update()
    {
        vert = moveYou.y;
        moveYou = Vector3.zero;
        if (Input.GetKey("w"))
            moveYou = Vector3.forward + moveYou;
        if (Input.GetKey("s"))
            moveYou = Vector3.back + moveYou;
        if (Input.GetKey("d"))
            moveYou = Vector3.right + moveYou;
        if (Input.GetKey("a"))
            moveYou = Vector3.left + moveYou;
        moveYou = ((cam.right * moveYou.x) + (cam.forward * moveYou.z)) * speed;
        if (pc.isGrounded)
        {
                if (Input.GetKeyDown("space"))
                    vert = jump;
                else
                    vert = 0;
        }
        moveYou.y = vert;
        moveYou.y = moveYou.y - (20 * Time.deltaTime);
        if (p2.position.y < -30.0f)
            moveYou = Vector3.zero;
        pc.Move(moveYou * Time.deltaTime);
        if (p2.position.y < -30.0f)
            p2.position = new Vector3(0, 10, 0);
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
