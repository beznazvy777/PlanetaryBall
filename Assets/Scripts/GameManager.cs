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
        GameObject newBall = Instantiate(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
        newBall.gameObject.transform.Rotate(0f, 90f, 0f);
        BallEnterInGame(newBall);
    }
}
