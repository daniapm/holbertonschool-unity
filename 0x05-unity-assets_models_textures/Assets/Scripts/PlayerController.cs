using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float thrust = 10;
    public bool is_grounded;

    //3D vectors and points.
    Vector3 translateObj;
    Vector3 rotateObj;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        is_grounded = true;
    }


    void FixedUpdate()
    {

        translateObj.x = Input.GetAxis("Horizontal");
        translateObj.z = Input.GetAxis("Vertical");
        transform.Translate(translateObj * speed * Time.deltaTime) ; 
        
        rotateObj.x = Input.GetAxis("Vertical");
        rotateObj.z = Input.GetAxis("Horizontal");
        transform.Rotate(rotateObj * speed * Time.deltaTime) ;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded == true)
        {
            Jump();
        }
        
    }
    void Jump()
    {
        is_grounded = false;
        rb.AddForce(0, thrust, 0, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            is_grounded = true;
        }
    }
}

