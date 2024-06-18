using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Skins
{
    Default,
    Galaxy,
    Disco,
    Gold
}
public class SkinManager : MonoBehaviour
{

    public event EventHandler OnNotEnoughMoney;
    public event EventHandler OnAlreadyAvailablePanel;

    public Skins skins;
    [Header("Skin Price")]
    [SerializeField] private int galaxySkinPrice;
    [SerializeField] private int discoSkinPrice;
    [SerializeField] private int goldSkinPrice;

    [Space]
    [SerializeField] private int galaxySkin;
    [SerializeField] private int discoSkin;
    [SerializeField] private int goldSkin;

    [Header("Set Skin Number")]
    [SerializeField] private int defaultSkinSetNum;
    [SerializeField] private int galaxySkinSetNum;
    [SerializeField] private int discoSkinSetNum;
    [SerializeField] private int goldSkinSetNum;

    int setSkinNumber;

    ScoreManager scoreManager;
    void Awake()
    {
        galaxySkin = PlayerPrefs.GetInt("GalaxySkin");
        discoSkin = PlayerPrefs.GetInt("DiscoSkin");
        goldSkin = PlayerPrefs.GetInt("GoldSkin");

        Debug.Log("Galaxy:" + galaxySkin);
        Debug.Log("Disco:" + discoSkin);
        Debug.Log("Goldalaxy:" + goldSkin);

        setSkinNumber = PlayerPrefs.GetInt("SkinNumber");
        SkinObject();
    }
    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        
    }

    

    public void BuyGalaxySkin()
    {
        if (galaxySkin == 0)
        {
            if (scoreManager.score >= galaxySkinPrice)
            {
                scoreManager.score -= galaxySkinPrice;
                galaxySkin = 1;
                PlayerPrefs.SetInt("GalaxySkin", galaxySkin);
            }
            else
            {
                OnNotEnoughMoney?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            OnAlreadyAvailablePanel?.Invoke(this, EventArgs.Empty);
            Debug.Log("You have this skin!");
        }

    }

    public void BuyDiscoSkin()
    {
        if (discoSkin == 0)
        {
            if (scoreManager.score >= discoSkinPrice)
            {
                scoreManager.score -= discoSkinPrice;
                discoSkin = 1;
                PlayerPrefs.SetInt("DiscoSkin", discoSkin);
            }
            else
            {
                OnNotEnoughMoney?.Invoke(this, EventArgs.Empty);
            }

        }
        else
        {
            OnAlreadyAvailablePanel?.Invoke(this, EventArgs.Empty);
            Debug.Log("You have this skin!");
        }
    }

    public void BuyGoldSkin()
    {
        if (goldSkin == 0)
        {
            if (scoreManager.score >= goldSkinPrice)
            {
                scoreManager.score -= goldSkinPrice;
                goldSkin = 1;
                PlayerPrefs.SetInt("GoldSkin", goldSkin);
            }
            else
            {
                OnNotEnoughMoney?.Invoke(this, EventArgs.Empty);
            }

        }
        else
        {
            OnAlreadyAvailablePanel?.Invoke(this, EventArgs.Empty);
            Debug.Log("You have this skin!");
        }
    }

    public int SetSkinObject(int number)
    {
        //Selected skin for player
        PlayerPrefs.SetInt("SkinNumber",number);
        setSkinNumber = PlayerPrefs.GetInt("SkinNumber");
        return setSkinNumber;
    }
    public void SetDefaultSkin()
    {
        SetSkinObject(defaultSkinSetNum);
    }
    public void SetGalaxySkin()
    {
        SetSkinObject(galaxySkinSetNum);
    }
    public void SetDiscoSkin()
    {
        SetSkinObject(discoSkinSetNum);
    }
    public void SetGoldSkin()
    {
        SetSkinObject(goldSkinSetNum);
    }

    public void SkinObject()
    {
        //Assign a number to the object
        switch (setSkinNumber)
        {
            case 0:
                skins = Skins.Default;
                break;

            case 1:
                skins = Skins.Galaxy;
                break;
            case 2:
                skins = Skins.Disco;
                break;
            case 3:
                skins = Skins.Gold;
                break;
        }
    }
}
