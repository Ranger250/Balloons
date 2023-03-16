using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Rigidbody rig;
    public float power;
    private float movepower = .2f;
    private bool bowled;
    public float move_step;
    public Vector3 startpos;
    public Quaternion startRot;
    public Vector3 startVel;
    public BowlingScript controller;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        startpos = transform.position;
        startRot = transform.rotation;
        startVel = Vector3.zero;
        controller = FindObjectOfType<BowlingScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bowled = false;
        //bowl();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0f)
        {
            resetBall();
        }
        if (transform.position.z > 10.5f)
        {
            resetBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("pin") || other.CompareTag("top of pin"))
        {
            return;
        }
        resetBall();
    }

    public void bowl()
    {
        rig.AddForce(Vector3.forward*power, ForceMode.Impulse);
        bowled = true;
    }

    public void move_left()
    {
        if (!bowled)
        {
            transform.position += Vector3.left * movepower;
        }
        
    }

    public void move_right()
    {
        if (!bowled)
        {
            transform.position += Vector3.right * movepower;
        }
    }

    public void resetBall()
    {
        rig.velocity = startVel;
        transform.position = startpos;
        transform.rotation = startRot;
        controller.scorePins();
    }
}
