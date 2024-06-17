using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkillsManager : MonoBehaviour
{
    public event EventHandler OnSpeedRoot;
    public event EventHandler OnBonusLive;
    public event EventHandler OnMenuIsOpen;
    public event EventHandler OnMenuIsClosed;
    [Header("Use Values")]
    [SerializeField] public int speedRootValues;
    [SerializeField] public int bonusLiveValues;
    [Header ("Shop Price")]
    [SerializeField] private int speedRootPrice;
    [SerializeField] private int bonusLivePrice;
    [Header("Text")]
    [SerializeField] private Text speedRootText;
    [SerializeField] private Text bonusLiveText;
    [Header("No Money Panel")]
    [SerializeField] private GameObject noMoneyPanel;
    [SerializeField] private GameObject alreadyAvailablePanel;


    ScoreManager scoreManager;
    SkinManager skinManager;
    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        skinManager = GetComponent<SkinManager>();

        skinManager.OnNotEnoughMoney += SkinManager_OnNotEnoughMoney;
        skinManager.OnAlreadyAvailablePanel += SkinManager_OnAlreadyAvailablePanel;
        noMoneyPanel.SetActive(false);
    }

    private void SkinManager_OnAlreadyAvailablePanel(object sender, EventArgs e)
    {
        StartCoroutine("AlreadyAvailablePanel");
    }

    private void SkinManager_OnNotEnoughMoney(object sender, EventArgs e)
    {
        StartCoroutine("NoScorePanel");
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
        else {
            StartCoroutine("NoScorePanel");
        }
    }

    public void BuyBonusLive() {
        if (scoreManager.score >= bonusLivePrice) {
            scoreManager.score -= bonusLivePrice;
            bonusLiveValues++;
            bonusLiveText.text = bonusLiveValues.ToString();
        }
        else {
            StartCoroutine("NoScorePanel");
        }
    }

    public IEnumerator NoScorePanel() {
        noMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        noMoneyPanel.SetActive(false);
    }

    public IEnumerator AlreadyAvailablePanel()
    {
        alreadyAvailablePanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        alreadyAvailablePanel.SetActive(false);
    }

    public void MenuOpen() {
        OnMenuIsOpen?.Invoke(this, EventArgs.Empty);
    }

    public void MenuClosed() {
        OnMenuIsClosed?.Invoke(this, EventArgs.Empty);
    }

}
