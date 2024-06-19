using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameOverManager : MonoBehaviour
{
    public event EventHandler OnGameIsOver;
    [SerializeField] private Text textLive;
    public float liveValue;

    [Header("Winner Panel")]
    [SerializeField] private GameObject winnerPanelUI;
    [SerializeField] private Text winnerTextScore;

    [Header("Game Over Panel")]
    [SerializeField] private GameObject gameOverPanelUI;

    SkillsManager skillManager;
    ScoreManager scoreManager;
    void Start()
    {
        skillManager = GetComponent<SkillsManager>();
        skillManager.OnBonusLive += SkillManager_OnBonusLive;

        scoreManager = GetComponent<ScoreManager>();
        scoreManager.OnPlayerWin += ScoreManager_OnPlayerWin;

        winnerPanelUI.SetActive(false);
        gameOverPanelUI.SetActive(false);
    }

    private void ScoreManager_OnPlayerWin(object sender, System.EventArgs e) {
        //Player Win Game!
        PlayerWinGame();
    }

    private void SkillManager_OnBonusLive(object sender, System.EventArgs e) {

        liveValue++;
    }

    void Update()
    {
        textLive.text = liveValue.ToString();
        if(liveValue <= 0) {
            liveValue = 0;
            GameOver();
            OnGameIsOver?.Invoke(this, EventArgs.Empty);
        }
    }

    public void GameOver() {
        Debug.Log("Game Over!");
        gameOverPanelUI.SetActive(true);
        scoreManager.score = 0;
        PlayerPrefs.SetInt("Score", 0);
    }

    public void PlayerWinGame() {
        winnerPanelUI.SetActive(true);
        winnerTextScore.text = "SCORE: " + scoreManager.score.ToString();
        PlayerPrefs.SetInt("Score", scoreManager.score);
        Debug.Log("Player Win Game");
    }
}
