using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public event EventHandler OnGoal;

    GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball") {


            Destroy(collision.gameObject);
            OnGoal?.Invoke(this, EventArgs.Empty);
            gameManager.RestartGameBall();




        }
    }
}
