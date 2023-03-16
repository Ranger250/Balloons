using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] private int score;
    public TextMeshProUGUI scoreText;
    private AudioSource audio;
    public GameObject[] prefabs;
    int counter = 0;


    private void Awake()
    {
        score = 0;
        scoreText = GameObject.FindWithTag("score").GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("Score: " + score.ToString());


        for (int i = 0; i < 10; i++)
        {
            spawn();
        }

    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter / 60 >= 8)
        {
            spawn();
            counter = 0;
        }
    }

    private void spawn()
    {
        int num = Random.Range(0, prefabs.Length);
        int x = Random.Range(-10, 8);
        int y = Random.Range(4, 10);
        int z = Random.Range(6, 20);
        Instantiate(prefabs[num], new Vector3(x, y, z), Quaternion.identity);
    }

    public void updateScore(int value)
    {
        score += value;
        scoreText.SetText("Score: " + score.ToString());
        spawn();
    }
}
