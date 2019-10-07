using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    Text scoreText;

    private void Awake()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score:" + score;
    }
}
