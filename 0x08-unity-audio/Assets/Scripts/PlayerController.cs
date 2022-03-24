using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController pc;
    private Transform player2;
    public Transform cam;
    private Vector3 moveYou = Vector3.zero;
    private Vector3 faceYou = Vector3.zero;
    private Quaternion faceRot;
    private float fall = 0f;
    public float speed = 10f;
    public float jump = 13f;
    private float vert;
    private Animator animation;
    public Canvas pause;
    private Transform ty_anim;
    private string surface;
    
    
    void Awake()
    {
        pc = GetComponent<CharacterController>();
        player2 = GetComponent<Transform>();
        ty_anim = player2.Find("ty");
        animation = ty_anim.GetComponent<Animator>();
    }

    void OnCollinsionStay(Collision other) {
        if (other.collider.tag == "Stone") {
            surface = "Stone";
        }
        else {
            surface = "Grass";
        }
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
            fall = 0;
            animation.SetBool("Grounded", true);
            if (Input.GetKeyDown("space"))
            {
                vert = jump;
                animation.SetTrigger("Jump");
            }
            else
                vert = 0;    
        }
        else
        {
            fall += Time.deltaTime;
            animation.SetBool("Grounded", false);
        }

        if (moveYou != Vector3.zero)
        {
            faceYou = new Vector3(moveYou.x, 0, moveYou.z);
            animation.SetBool("Moving", true);
        }
        else
        {
            animation.SetBool("Moving", false);
        }
        moveYou.y = vert;
        moveYou.y = moveYou.y - (20 * Time.deltaTime);
        pc.Move(new Vector3(moveYou.x, moveYou.y, moveYou.z) * Time.deltaTime);
        if (moveYou != Vector3.zero)
        {
            faceRot = Quaternion.LookRotation(faceYou);
            ty_anim.rotation = faceRot;
        }
        animation.SetFloat("Fall", fall);
        if (player2.position.y < -50.0f)
            player2.position = new Vector3(0, 2, 0);
        if (Input.GetKeyDown("escape"))
        {
            pause.GetComponent<PauseMenu>().Pause();
        }
    }

    public bool onGround()
    {
        return pc.isGrounded;
    }

    public string surfaceType()
    {
        return surface;
    }
}
