using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButton : MonoBehaviour
{

    public AudioSource sfx;
    public AudioClip hover;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hover()
    {
        sfx.PlayOneShot(hover);
    }
    public void Click()
    {
        sfx.PlayOneShot(click);
    }
}
