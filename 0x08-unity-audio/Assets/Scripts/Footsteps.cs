using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private string surface;
    public AudioClip rock;
    public AudioClip grass;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FootstepSFX()
    {
        bool grounded = player.GetComponent<PlayerController>().onGround();
        if (grounded)
        {
            if (player.GetComponent<PlayerController>().surfaceType() == "Stone")
                GetComponent<AudioSource>().PlayOneShot(rock);
            else
                GetComponent<AudioSource>().PlayOneShot(grass);
        }
    }
}
