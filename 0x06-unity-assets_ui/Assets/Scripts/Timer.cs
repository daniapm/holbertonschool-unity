using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public UnityEngine.UI.Text TimerText;
    public float timeGame = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeGame += Time.deltaTime;
        TimerText.text = string.Format("{1:0}:{0:00.00}", timeGame % 60, timeGame / 60);

    }
}
