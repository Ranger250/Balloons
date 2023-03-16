using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkiingController : MonoBehaviour
{
    public int lives;
    public PlayerScript player;


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health <= 0)
        {
            player.resetPlayer();
            lives--;

        }
        if(lives <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
