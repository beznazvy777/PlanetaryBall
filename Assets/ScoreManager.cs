using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int pointsWhenHit;

    [SerializeField] private Text scoreText;
    GoalManager goalManager;

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
    }
}
