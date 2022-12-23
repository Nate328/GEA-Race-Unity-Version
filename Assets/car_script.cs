using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_script : MonoBehaviour
{
    public float accel;
    private float drive;
    private float turn;
    public Rigidbody car;

    // Update is called once per frame
    void FixedUpdate()
    {
        drive = Input.GetAxis("Forward");
        if (drive > 0)
        {
            car.AddRelativeForce(new Vector3(0, 0, drive * accel));
        }
        turn = Input.GetAxis("Turn");
        if (turn != 0)
        {
            car.AddTorque(new Vector3(0, turn, 0));
        }
    }
}
