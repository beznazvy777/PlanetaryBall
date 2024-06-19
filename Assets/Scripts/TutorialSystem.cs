using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField] private int tutorialStep;

    [SerializeField] private GameObject Step0;
    [SerializeField] private GameObject Step1;
    [SerializeField] private GameObject Step2;
    [SerializeField] private GameObject Step3;
    [SerializeField] private GameObject Step4;
    [SerializeField] private GameObject Step5;

    void Start()
    {
        tutorialStep = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            tutorialStep++;
            TutorialSelecter();
        }
    }

    public void TutorialSelecter()
    {
        switch(tutorialStep)
        {
            case 0:
                Step0.SetActive(true);
                break;
            case 1:
                Step1.SetActive(true);
                Step0.SetActive(false);
                break;
            case 2:
                Step2.SetActive(true);
                Step1.SetActive(false);
                break;
            case 3:
                Step3.SetActive(true);
                Step2.SetActive(false);
                break;
            case 4:
                Step4.SetActive(true);
                Step3.SetActive(false);
                break;
            case 5:
                Step5.SetActive(true);
                Step4.SetActive(false);
                break;
            case 6:
                
                Step5.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }
}
