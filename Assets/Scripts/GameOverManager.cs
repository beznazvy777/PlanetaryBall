using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    
    [SerializeField] private Text textLive;
    public float liveValue;

    SkillsManager skillManager;
    ScoreManager scoreManager;
    void Start()
    {
        skillManager = GetComponent<SkillsManager>();
        skillManager.OnBonusLive += SkillManager_OnBonusLive;

        scoreManager = GetComponent<ScoreManager>();
        scoreManager.OnPlayerWin += ScoreManager_OnPlayerWin;
        
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
        }
    }

    public void GameOver() {
        Debug.Log("Game Over!");
    }

    public void PlayerWinGame() {
        Debug.Log("Player Win Game");
    }
}
