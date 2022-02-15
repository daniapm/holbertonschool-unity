using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 15f;
    private float vert;
    private CharacterController controler;
    private Transform trans;
    public Transform camara;
    private Vector3 moveYou = Vector3.zero;
    

    void Awake()
    {
        controler = GetComponent<CharacterController>();
        trans = GetComponent<Transform>();
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
        moveYou = ((camara.right * moveYou.x) + (camara.forward * moveYou.z)) * speed;
        if (controler.isGrounded)
        {
                if (Input.GetKeyDown("space"))
                    vert = jump;
                else
                    vert = 0;
        }
        moveYou.y = vert;
        moveYou.y = moveYou.y - (20 * Time.deltaTime);
        if (trans.position.y < -30.0f)
            moveYou = Vector3.zero;
        controler.Move(moveYou * Time.deltaTime);
        if (trans.position.y < -30.0f)
            trans.position = new Vector3(0, 10, 0);
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
