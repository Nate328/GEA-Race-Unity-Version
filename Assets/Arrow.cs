using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject tracker;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int progress = tracker.GetComponent<Race_Tracker>().pos;
        Vector3 nextpos =  tracker.transform.GetChild(progress).position;
        Vector3 carpos = car.transform.position;
        Vector3 carforward = car.transform.forward;
        Vector3 toVector = nextpos - carpos;

        Vector3 perp = Vector3.Cross(carforward, toVector);
        float dir = Vector3.Dot(perp, Vector3.up);
		
        if (dir > 2f) {
            arrow.transform.eulerAngles = new Vector3(0, 0, 90);;
        } else if (dir < -2f) {
            arrow.transform.eulerAngles = new Vector3(0, 0, -90);
        } else {
            arrow.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
