using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody rig;
    private Vector3 startpos;
    private Quaternion startrot;
    private Vector3 startvel;
    private float xInput;
    public float xforce;
    private float yInput;
    public float jumpForce;
    public int health;
    public bool grounded;
    public MeshRenderer mr;
    public Color green;
    public Color yellow;
    public Color red;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        startpos = transform.position;
        startrot = transform.rotation;
        startvel = Vector3.zero;
        health = 3;
        grounded = true;
        mr.material.color = green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Jump");

        //moving left and right
        rig.AddForce(Vector3.right * xInput * xforce);

        //jumping
        if(grounded && yInput > 0)
        {
            grounded = false;
            rig.AddForce(Vector3.up * yInput * jumpForce, ForceMode.Impulse);
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = isGrounded();
        }
        if (collision.gameObject.CompareTag("badStuff"))
        {
            damagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        softReset();
    }

    public void damagePlayer()
    {
        //take away health
        health--;
        //change player color to match health
        if (health == 2)
        {
            mr.material.color = yellow;
        }
        if (health < 2)
        {
            mr.material.color = red;
        }
        //bounce off object
        rig.AddForce(Vector3.back * 20, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool isGrounded()
    {
        return true;
    }

    public void resetPlayer()
    {
        rig.isKinematic = true;
        transform.position = startpos;
        transform.rotation = startrot;
        rig.velocity = startvel;
        health = 3;
        grounded = true;
        mr.material.color = green;
        rig.isKinematic = false;

    }

    public void softReset()
    {
        
        transform.position = startpos;
        transform.rotation = startrot;
        grounded = true;

    }
}
