using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race_Tracker : MonoBehaviour
{
    public int pos;
    public int racelength;
    public bool race;
    public bool begin;
    public int lap;
    public int lapmax;

    public int aipos;
    public int ailap;
    
    public Material nextmat;
    public GameObject aicar;
    public GameObject ui;
    
    // Start is called before the first frame update
    void Start()
    {
        racelength = transform.childCount;
        race = false;
        begin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (race)
        {
            ui.GetComponent<UIsetter>().Increment();
            if (pos == racelength)
            {
                pos = 0;
                lap += 1;
                if (lap == lapmax)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    aipos = 0;
                    lap = 0;
                    ailap = 0;
                    ui.GetComponent<UIsetter>().counter.text = "Race Won!";
                    race = false;
                }
            }

            if (aipos == racelength)
            {
                aipos = 0;
                ailap += 1;
                if (ailap == lapmax)
                {
                    aicar.GetComponent<ai_script>().stop = true;
                    pos = 0;
                    lap = 0;
                    ailap = 0;
                    ui.GetComponent<UIsetter>().counter.text = "Race Lost!";
                    transform.GetChild(0).gameObject.SetActive(true);
                    race = false;
                }
            }

            if (begin)
            {
                for (int i = 1; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
                lap = 0;
                aicar.GetComponent<ai_script>().stop = false;
                begin = false;
            }
        }
    }

    public void NextCheck()
    {
        if (pos == racelength)
        {transform.GetChild(0).GetComponent<MeshRenderer>().material = nextmat; }
        else
        {transform.GetChild(pos).GetComponent<MeshRenderer>().material = nextmat;}
    }
}
