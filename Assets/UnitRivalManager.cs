using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class UnitRivalManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBall;
    [SerializeField] private Transform RivalIdlePoint;
    NavMeshAgent navMesh;
    

    [Header("Values")]
    [SerializeField] private float moveSpeed;

    GameManager gameManager;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnBallInGame += GameManager_OnBallInGame;
        
    }

    private void GameManager_OnBallInGame(GameObject gameObject) {

        //Event to add player ball for targeting
        PlayerBall = gameObject;
    }

    void Update()
    {
        

        if (PlayerBall)
        {

            // Rotate and moving unit(rival) to target (player ball)
            Vector3 direction = PlayerBall.transform.position - this.transform.position;
            
            float angle = Mathf.Atan2(direction.y, direction.x);
            this.transform.rotation = Quaternion.Euler(0f,0f,angle * Mathf.Rad2Deg);


                
            navMesh.SetDestination(PlayerBall.transform.position);
            


        }

        if (!PlayerBall) {


            //Rotate and moving unit(rival) to waitPoint
            Vector3 direction = RivalIdlePoint.position - this.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x);
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            navMesh.SetDestination(RivalIdlePoint.position);
        }

        
    }

    public void OnCollisionEnter2D (Collision2D collision) {
        

        //Unit rival interact with player ball,rotate and knocks to the side
        if(collision.gameObject.tag == "Ball") {
            collision.gameObject.GetComponentInChildren<BallRotator>().StartCoroutine("RotateTheBall");
                collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(
                new Vector2(Random.RandomRange(-1, 1), Random.RandomRange(-1, 1)) * 750f
                );
                
            
            
        }
        return;
    }

    
}
