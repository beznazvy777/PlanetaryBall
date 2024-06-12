using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    public event EventHandler OnSpeedRoot;
    public event EventHandler OnBonusLive;
    [Header("Use Values")]
    [SerializeField] public int speedRootValues;
    [SerializeField] public int bonusLiveValues;
    [Header ("Shop Price")]
    [SerializeField] private int speedRootPrice;
    [SerializeField] private int bonusLivePrice;
    [Header("Text")]
    [SerializeField] private Text speedRootText;
    [SerializeField] private Text bonusLiveText;


    ScoreManager scoreManager;
    void Start()
    {
        scoreManager = GetComponent<ScoreManager>(); 
    }

    
    void Update()
    {
        
    }

    public void SpeedRootSkill() {
        if(speedRootValues > 0) {
            speedRootValues -= 1;
            OnSpeedRoot?.Invoke(this, EventArgs.Empty);
            speedRootText.text = speedRootValues.ToString();
            if (speedRootValues <= 0) {
                speedRootValues = 0;
            }
        }
        
    }

    public void BonusLiveSkill() {
        if (bonusLiveValues > 0) {
            bonusLiveValues -= 1;
            OnBonusLive?.Invoke(this, EventArgs.Empty);
            bonusLiveText.text = bonusLiveValues.ToString();
            if (bonusLiveValues <= 0) {
                bonusLiveValues = 0;
            }
        }
    }

    public void BuySpeedRoot() {
        if(scoreManager.score >= speedRootPrice) {
            scoreManager.score -= speedRootPrice;
            speedRootValues++;
            speedRootText.text = speedRootValues.ToString();
        }
    }

    public void BuyBonusLive() {
        if (scoreManager.score >= bonusLivePrice) {
            scoreManager.score -= bonusLivePrice;
            bonusLiveValues++;
            bonusLiveText.text = bonusLiveValues.ToString();
        }
    }
}
