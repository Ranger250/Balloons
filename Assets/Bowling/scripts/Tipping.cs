using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tipping : MonoBehaviour
{
    public PinScript pin;
    // Start is called before the first frame update
    void Start()
    {
        pin = GetComponentInParent<PinScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pin"))
        {
            return;
        }
        pin.knockedDown();
    }
}
