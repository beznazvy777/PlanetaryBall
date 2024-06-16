using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class UnitRivalManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBall;
    [SerializeField] private Transform RivalIdlePoint;
    [SerializeField] private GameObject RunAnimationFront;
    [SerializeField] private GameObject RunAnimationBack;

    NavMeshAgent navMesh;
    

    [Header("Values")]
    [SerializeField] private float moveSpeed;

    SkillsManager skillsManager;
    GameManager gameManager;
    float posYDestination;
    bool canMove;
    void Start()
    {
        canMove = true;

        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;

        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnBallInGame += GameManager_OnBallInGame;

        skillsManager = FindObjectOfType<SkillsManager>();
        skillsManager.OnSpeedRoot += SkillsManager_OnSpeedRoot;
        skillsManager.OnMenuIsOpen += SkillsManager_OnMenuIsOpen;
        skillsManager.OnMenuIsClosed += SkillsManager_OnMenuIsClosed;
        
    }

    private void SkillsManager_OnMenuIsClosed(object sender, System.EventArgs e) {
        canMove = true;
    }

    private void SkillsManager_OnMenuIsOpen(object sender, System.EventArgs e) {
        canMove = false;
    }

    private void SkillsManager_OnSpeedRoot(object sender, System.EventArgs e) {
        //Start root
        StartCoroutine("RootStart");
    }

    private void GameManager_OnBallInGame(GameObject gameObject) {

        //Event to add player ball for targeting
        PlayerBall = gameObject;
    }

    void Update()
    {
        float posY = transform.position.y;
        

        if (posY < posYDestination) {
            RunAnimationFront.SetActive(true);
            RunAnimationBack.SetActive(false);
        }
        if (posY >= posYDestination) {
            RunAnimationFront.SetActive(false);
            RunAnimationBack.SetActive(true);
        }

        if (canMove) {
            if (PlayerBall) {

                // Rotate and moving unit(rival) to target (player ball)
                //Vector3 direction = PlayerBall.transform.position - this.transform.position;

                //float angle = Mathf.Atan2(direction.y, direction.x);
                //this.transform.rotation = Quaternion.Euler(0f,0f,angle * Mathf.Rad2Deg);



                navMesh.SetDestination(PlayerBall.transform.position);



            }

            if (!PlayerBall) {


                //Rotate and moving unit(rival) to waitPoint
                //Vector3 direction = RivalIdlePoint.position - this.transform.position;

                //float angle = Mathf.Atan2(direction.y, direction.x);

                //this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
                navMesh.SetDestination(RivalIdlePoint.position);

            }

            posYDestination = transform.position.y;
        }
        else {
            navMesh.SetDestination(transform.position);
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

    public IEnumerator RootStart() {

        float speed = navMesh.speed;
        navMesh.speed = navMesh.speed / 2;

        yield return new WaitForSeconds(10);

        navMesh.speed = speed;
    }
}
