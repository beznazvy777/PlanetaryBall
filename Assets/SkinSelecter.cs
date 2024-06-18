using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelecter : MonoBehaviour
{
    [SerializeField] private int skinCounter;

    [SerializeField] private GameObject SoccerImage;
    [SerializeField] private GameObject GalaxyImage;
    [SerializeField] private GameObject DiscoImage;
    [SerializeField] private GameObject GoldImage;

    [Space]
    [SerializeField] private GameObject SelectedSoccerButton;
    [SerializeField] private GameObject SelectedGalaxyButton;
    [SerializeField] private GameObject SelectedDiscoButton;
    [SerializeField] private GameObject SelectedGoldButton;
    [SerializeField] private GameObject ClosedButton;


    
    void Start()
    {
        ShowSkin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightArrowButton()
    {
        if(skinCounter < 3)
        {
            skinCounter++;
            ShowSkin();
        }
        
    }

    public void LeftArrowButton()
    {
        if (skinCounter > 0)
        {
            skinCounter--;
            ShowSkin();
        }

    }
    public void ShowSkin()
    {
        switch (skinCounter)
        {
            case 0:
                SoccerImage.SetActive(true);
                SelectedSoccerButton.SetActive(true);


                GalaxyImage.SetActive(false);
                DiscoImage.SetActive(false);
                GoldImage.SetActive(false);

                SelectedGalaxyButton.SetActive(false);
                SelectedDiscoButton.SetActive(false);
                SelectedGoldButton.SetActive(false);

                ClosedButton.SetActive(false);

                break;
            case 1:

                GalaxyImage.SetActive(true);

                SoccerImage.SetActive(false);
                DiscoImage.SetActive(false);
                GoldImage.SetActive(false);
                int galaxyValue = PlayerPrefs.GetInt("GalaxySkin");
                if(galaxyValue == 1)
                {
                    SelectedGalaxyButton.SetActive(true);
                    
                    
                }
                else
                {
                    ClosedButton.SetActive(true);
                }

                SelectedSoccerButton.SetActive(false);
                SelectedDiscoButton.SetActive(false);
                SelectedGoldButton.SetActive(false);

                break;
            case 2:
                DiscoImage.SetActive(true);

                SoccerImage.SetActive(false);
                GalaxyImage.SetActive(false);
                GoldImage.SetActive(false);
                int discoValue = PlayerPrefs.GetInt("DiscoSkin");
                if (discoValue == 1)
                {
                    SelectedDiscoButton.SetActive(true);

                    

                }
                else
                {
                    ClosedButton.SetActive(true);
                }

                SelectedSoccerButton.SetActive(false);
                SelectedGalaxyButton.SetActive(false);
                SelectedGoldButton.SetActive(false);

                break;
            case 3:
                GoldImage.SetActive(true);

                SoccerImage.SetActive(false);
                GalaxyImage.SetActive(false);
                DiscoImage.SetActive(false);

                int goldValue = PlayerPrefs.GetInt("GoldSkin");
                if (goldValue == 1)
                {
                    SelectedGoldButton.SetActive(true);

                    
                }
                else
                {
                    ClosedButton.SetActive(true);
                }

                SelectedDiscoButton.SetActive(false);
                SelectedSoccerButton.SetActive(false);
                SelectedGalaxyButton.SetActive(false);

                break;

        }
    }
}


