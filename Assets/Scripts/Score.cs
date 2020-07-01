using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int highScore = 0;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "SCORE : " + score.ToString();

    }

    public void AddScore(int num)
    {
        score += num;
        if (highScore <= score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
    public int GetScore()
    {
        return score;
    }
}
