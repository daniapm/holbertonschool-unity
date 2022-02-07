using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WinFlag")
        {
            text.GetComponent<Text>().color = Color.green;
            text.GetComponent<Text>().fontSize = 60;
        }
    }
}
