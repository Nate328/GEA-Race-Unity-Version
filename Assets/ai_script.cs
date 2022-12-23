using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_script : MonoBehaviour
{
    public GameObject tracker;
    public GameObject thiscar;
    public Rigidbody thisbody;

    public bool stop;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            int progress = tracker.GetComponent<Race_Tracker>().aipos;
            Vector3 nextpos = tracker.transform.GetChild(progress).position;
            Vector3 carpos = thiscar.transform.position;
            Vector3 carforward = thiscar.transform.forward;
            Vector3 toVector = nextpos - carpos;

            Vector3 perp = Vector3.Cross(carforward, toVector);
            float dir = Vector3.Dot(perp, Vector3.up);
            if (dir > 1.5f)
            {
                thisbody.AddTorque(new Vector3(0, 0.5f, 0));
            }
            else if (dir < -1.5f)
            {
                thisbody.AddTorque(new Vector3(0, -0.5f, 0));
            }
            else
            {
                Vector3 speed = thisbody.velocity;
                if (speed.x <= 9 && speed.z <= 9 && speed.x >= -9 && speed.z >= -9)
                {
                    thisbody.AddRelativeForce(new Vector3(0, 0, 3));
                }
            }
        }
    }
}
