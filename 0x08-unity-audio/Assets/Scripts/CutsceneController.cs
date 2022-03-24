using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    Animator animator;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject cut;
    public GameObject timerCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transition()
    {
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        cut.SetActive(false);
    }
}
