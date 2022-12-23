using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIsetter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public TextMeshProUGUI lcounter;
    public GameObject tracker;

    private int maxpoints;
    private int maxlaps;
    private void Start()
    {
        maxpoints = tracker.GetComponent<Race_Tracker>().racelength;
        maxlaps = tracker.GetComponent<Race_Tracker>().lapmax;
    }

    // Update is called once per frame
    public void Increment()
    {
        int progress = tracker.GetComponent<Race_Tracker>().pos;
        counter.text = progress+"/"+maxpoints;
        int lprogress = tracker.GetComponent<Race_Tracker>().lap;
        lcounter.text = lprogress+"/"+maxlaps;
    }
}
