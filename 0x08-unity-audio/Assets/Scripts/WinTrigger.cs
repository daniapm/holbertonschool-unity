using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    private bool win = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && win == false)
        {
            win = true;
            other.gameObject.GetComponent<Timer>().Win();
        }
    }
}
