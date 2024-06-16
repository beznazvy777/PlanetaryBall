using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public event EventHandler OnBallInGame;
    public delegate void EventHandler(GameObject gameObject);

    

    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Transform BallSpawnPoint;
    private GameObject ballInGame;

    ScoreManager scoreManager;
    GameOverManager gameOverManager;
    bool canSpawnBall;
    
    void Start() {
        scoreManager = GetComponent<ScoreManager>();
        scoreManager.OnPlayerWin += ScoreManager_OnPlayerWin;

        gameOverManager = GetComponent<GameOverManager>();
        gameOverManager.OnGameIsOver += GameOverManager_OnGameIsOver;
        canSpawnBall = true;
    }

    private void GameOverManager_OnGameIsOver(object sender, EventArgs e) {
        canSpawnBall = false;
        
    }

    private void ScoreManager_OnPlayerWin(object sender, EventArgs e) {
        canSpawnBall = false;
    }

    public void BallEnterInGame(GameObject ball) {

        //Create new player ball in game
        ballInGame = ball;
        OnBallInGame?.Invoke(ballInGame);
        ballInGame = null;
    }

    public void RestartGameBall() {

        StartCoroutine("BallCreation");
    }

    public IEnumerator BallCreation() {
        //Restart player ball in scene with effect
        yield return new WaitForSeconds(2);
    if (canSpawnBall) {
        GameObject newBall = Instantiate(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
        newBall.gameObject.transform.Rotate(0f, 90f, 0f);
        BallEnterInGame(newBall);
        }
        else {
            Debug.Log("Game is over");
        }
    }

    
}
