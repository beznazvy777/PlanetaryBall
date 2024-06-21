using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public event EventHandler OnGoal;

    [SerializeField] private GameObject goalPrefab;

    [Header("Sound")]
    [SerializeField] private AudioSource WinnerSound;
 
    GameManager gameManager;


    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball") {


            Destroy(collision.gameObject);
            OnGoal?.Invoke(this, EventArgs.Empty);
            gameManager.RestartGameBall();
            Instantiate(goalPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

            WinnerSound.Play();


        }
    }
}
