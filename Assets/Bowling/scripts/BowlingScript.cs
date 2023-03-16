using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingScript : MonoBehaviour
{

    public int score;
    public PinScript[] pins;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int value)
    {
        score += value;
    }

    public void scorePins()
    {
        foreach(PinScript pin in pins)
        {
            if(pin.knockedOver)
            {
                pin.addScore();
            }
            
            pin.resetPin();
        }
        scoreText.text = "Score: " + score.ToString();
    }

}
