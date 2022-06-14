using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    private ARPlaneManager pMan;
    private ARRaycastManager rMan;
    private List<ARRaycastHit> rayHits = new List<ARRaycastHit>();
    public ARPlane plane = null;
    public GameObject StartCanvas;
    public GameObject Target;
    public GameObject TestTarget;
    public GameObject TestBall;
    public GameObject RedTestBall;
    public List<GameObject> targets = new List<GameObject>();


    void Awake()
    {
        pMan = GetComponent<ARPlaneManager>();
        rMan = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        
        if (Input.touchCount > 0)
        {
            if (rMan.Raycast(Input.GetTouch(0).position, rayHits) && plane == null)
            {
                plane = pMan.GetPlane(rayHits[0].trackableId);
                foreach (ARPlane planes in pMan.trackables)
                {
                    if (planes != plane)
                    {
                        planes.gameObject.SetActive(false);
                    }
                }
                pMan.enabled = false;

                StartCanvas.SetActive(true);
                GameObject centerTarget = Instantiate(Target, plane.center + new Vector3(0, .03f, 0), Quaternion.identity);
                centerTarget.transform.SetParent(plane.transform);
                targets.Add(centerTarget);

                for (int i = 1; i < plane.boundary.Length - 1; i += plane.boundary.Length/4)
                {
                    GameObject randomTarget = Instantiate(Target, plane.center + new Vector3(((plane.boundary[i].x) / 2), .03f, ((plane.boundary[i].y) / 2)), Quaternion.identity);
                    randomTarget.transform.SetParent(plane.transform);
                    targets.Add(randomTarget);
                }
            }
        }
        
    }
}