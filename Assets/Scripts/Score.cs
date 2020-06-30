﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE : " + score.ToString();
    }

    public void AddScore(int num)
    {
        score += num;
    }
}
