using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{

    public event EventHandler OnBlockActive;
    public event EventHandler OnBlockWait;
    public event EventHandler OnBlockDeactive;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ballSprite;
    [SerializeField] private BlockCollisionManager blockCollisionManager;

    [Header ("Values")]
    [SerializeField] private float forwardVelocityPower;
    [SerializeField] private float interactCooldownSeconds;

    bool isBallInteract;
    bool isCanTrigger;

    void Start()
    {
        isCanTrigger = true;
        isBallInteract = false;
        blockCollisionManager.LaunchTheBall += BlockCollisionManager_LaunchTheBall;
    }

    private void BlockCollisionManager_LaunchTheBall(object sender, BlockCollisionManager.LaunchTheBallEventArgs e)
    {

        //Event to throw ball forward when his interact with unit
        if (!isCanTrigger) {
            forwardVelocityPower = e.forcePower;
            CreateAndPullBall();
            
            OnBlockWait?.Invoke(this, EventArgs.Empty);
        }
            

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    //Unit interact trigger system
    if (isCanTrigger)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (!isBallInteract)
            {
                //Unit interact with ball (destroy gameBall and create ballImage forward unit)
                Destroy(collision.gameObject);
                ballSprite.SetActive(true);
                Debug.Log("Unit interact");
                isBallInteract = true;
                OnBlockActive?.Invoke(this, EventArgs.Empty);
                isCanTrigger = false;

            }
        }
    }
    }

    public void CreateAndPullBall()
    {
        //Create ball gameobject,pull, and off Image
        if (isBallInteract)
        {
            GameObject newBallObject = Instantiate(ballPrefab, spawnPoint.position,Quaternion.identity);
            newBallObject.gameObject.transform.Rotate(0f, 90f, 0f);
            newBallObject.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(spawnPoint.forward * forwardVelocityPower * 10);
            
            ballSprite.SetActive(false);
            isBallInteract = false;

            Invoke("EnabledBallInteraction", interactCooldownSeconds);

        }
    }

    public void DisablingBallInteraction()
    {
        isBallInteract = false;
    }

    public void EnabledBallInteraction()
    {
        OnBlockDeactive?.Invoke(this, EventArgs.Empty);
        isCanTrigger = true;
    }

}
