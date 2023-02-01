using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private float currentScore;

    private float highScore;

    [SerializeField] private float comboTime;
    [SerializeField] private float levelTime;
    [SerializeField] private GameManager gameManager;

    public float comboCount { get; private set; }
    private bool isDoingCombo;
    private  float comboTimer, levelTimer;

    private void Start()
    {
        currentScore = 0;
        comboCount = 0;
        levelTimer = levelTime;

        scoreText.text = "Score: " + currentScore.ToString();
        timerText.text = levelTimer.ToString();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        comboTimer = comboTime;

        isDoingCombo = false;
    }
    private void Update()
    {
        CheckCombo();
        UpdateTimer();
    }

    public void UpdateScore(float points)
    {

        isDoingCombo = true;
        comboCount++;
        comboTimer = comboTime;

        currentScore += points * comboCount;
        scoreText.text = "Score: " + currentScore.ToString();
        PlayerPrefs.SetInt("LastScore", (int)currentScore);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)currentScore);
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
    }
    public void UpdateTimer()
    {
        levelTimer -= Time.deltaTime;
        string textForTimer = levelTimer.ToString("0.00");
        timerText.text = textForTimer;

        PlayerPrefs.SetInt("LevelTime", (int)levelTimer);

        if (levelTimer <= 0f)
        {
            gameManager.ReloadScene();
        }
    }

    private void CheckCombo()
    {
        if (isDoingCombo)
        {
            comboTimer -= Time.deltaTime;
        }
        if (comboTimer <= 0f)
        {
            comboCount = 0f;
            isDoingCombo = false;
            comboTimer = comboTime;
        }
    }

}
