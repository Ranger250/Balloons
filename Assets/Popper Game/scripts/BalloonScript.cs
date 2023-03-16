using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    public int clicksToPop = 3;
    public int value;
    public GameController controller;
    public AudioSource audio;



    private void Start()
    {
        controller = FindObjectOfType<GameController>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(.2f, .24f, .2f);
        clicksToPop--;
        if (clicksToPop == 0)
        {
            controller.updateScore(value);
            audio.Play();
            Destroy(gameObject, 0.2f);
        }
    }



}
