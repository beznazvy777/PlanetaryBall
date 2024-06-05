using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ballSprite;
    [SerializeField] private float forwardVelocityPower;
    [SerializeField] private BlockCollisionManager blockCollisionManager;
    bool isBallInteract;

    void Start()
    {
        isBallInteract = false;
        blockCollisionManager.LaunchTheBall += BlockCollisionManager_LaunchTheBall;
    }

    private void BlockCollisionManager_LaunchTheBall(object sender, BlockCollisionManager.LaunchTheBallEventArgs e)
    {
        forwardVelocityPower = e.forcePower;
        CreateAndPullBall();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Unit interact trigger system
        if (collision.gameObject.tag == "Ball")
        {
            if (!isBallInteract)
            {
                //Unit interact with ball (destroy gameBall and create ballImage forward unit)
                Destroy(collision.gameObject);
                ballSprite.SetActive(true);
                Debug.Log("Unit interact");
                isBallInteract = true;
                

            }
            
           
        }
    }

    public void CreateAndPullBall()
    {
        //Create ball gameobject,pull, and off Image
        if (isBallInteract)
        {
            GameObject newBallObject = Instantiate(ballPrefab, spawnPoint.position,Quaternion.identity);
            newBallObject.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(spawnPoint.forward * forwardVelocityPower * 10);
            
            ballSprite.SetActive(false);
            isBallInteract = false;

        }
    }
}
