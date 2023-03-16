using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rig;
    public Vector3 startpos;
    public Quaternion startRot;
    public Vector3 startVel;
    public bool knockedOver;
    public int value;
    public BowlingScript controller;


    private void Awake()
    {
        controller = FindObjectOfType<BowlingScript>();
        value = 1;
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = false;
        startpos = transform.position;
        startRot = transform.rotation;
        startVel = Vector3.zero;
        knockedOver = false;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPin()
    {
        rig.isKinematic = true;
        rig.velocity = startVel;
        transform.position = startpos;
        knockedOver = false;
        transform.rotation = startRot;
        rig.isKinematic = false;
    }

    public void addScore()
    {
        controller.addScore(value);
    }

    public void knockedDown()
    {
        knockedOver = true;
    }
}
