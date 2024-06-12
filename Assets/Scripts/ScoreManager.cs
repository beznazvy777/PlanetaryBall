using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] private int pointsWhenHit;
    [SerializeField] private int goals;

    [SerializeField] private Text scoreText;
    GoalManager goalManager;

    [Header("Goal Visual")]

    [SerializeField] private GameObject Ball_1;
    [SerializeField] private GameObject Ball_2;
    [SerializeField] private GameObject Ball_3;
    [SerializeField] private GameObject Ball_4;

    public event EventHandler OnPlayerWin;

    private void Start() {
        goalManager = FindObjectOfType<GoalManager>();
        goalManager.OnGoal += GoalManager_OnGoal;
    }

    private void Update() {
        scoreText.text = "Score: " + score.ToString();
    }

    private void GoalManager_OnGoal(object sender, System.EventArgs e) {

        //Update score when player ball trigger goal gates
        score += pointsWhenHit;
        if (goals <= 4) {
            goals++;
            VisualGoals();
        }

    }

    public void VisualGoals() {

        //Show balls in ball-goal visual panel

        if(goals <= 4) {
            switch (goals) {
                case 1:
                    Ball_1.SetActive(true);
                    break;
                case 2:
                    Ball_2.SetActive(true);
                    break;
                case 3:
                    Ball_3.SetActive(true);
                    break;
                case 4:
                    Ball_4.SetActive(true);
                    OnPlayerWin?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }
        else {
            //Player win! All balls get goal
            OnPlayerWin?.Invoke(this, EventArgs.Empty);


        }
    }

    
}
