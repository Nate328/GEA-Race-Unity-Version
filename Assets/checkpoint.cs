using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int num;
    public GameObject tracker;
    public char type;
    public Material basemat;

    void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            if (tracker.GetComponent<Race_Tracker>().pos == (num - 1))
            {
                tracker.GetComponent<Race_Tracker>().pos += 1;
                gameObject.GetComponent<MeshRenderer>().material = basemat;
                if (tracker.GetComponent<Race_Tracker>().lap == tracker.GetComponent<Race_Tracker>().lapmax - 1)
                {
                    gameObject.SetActive(false);
                }

                tracker.GetComponent<Race_Tracker>().NextCheck();

                if (type == 'S' && tracker.GetComponent<Race_Tracker>().lap == 0)
                {
                    tracker.GetComponent<Race_Tracker>().race = true;
                    tracker.GetComponent<Race_Tracker>().begin = true;
                }
            }
        }
        else
        {
            if (tracker.GetComponent<Race_Tracker>().aipos == (num - 1))
            {
                tracker.GetComponent<Race_Tracker>().aipos += 1;
            }
        }
    }
}
