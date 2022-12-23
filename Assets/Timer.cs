using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI clock;
    public GameObject tracker;
    private float secs = 0f;
    private int mins = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (tracker.GetComponent<Race_Tracker>().race)
        {
            secs += Time.deltaTime;
            if (((int) secs) >= 60)
            {
                mins += 1;
                secs = 0f;
            }

            clock.text = (mins.ToString("00")) + ":" + (((int) secs).ToString("00"));
        }
        else
        {
            secs = 0;
            mins = 0;
        }
    }
}
