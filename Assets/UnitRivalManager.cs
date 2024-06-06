using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitRivalManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBall;
    NavMeshAgent navMesh;
    //[SerializeField] private Rigidbody2D rb;

    [Header("Values")]
    [SerializeField] private float moveSpeed;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        if (!PlayerBall)
            PlayerBall = FindObjectOfType<BallManager>().gameObject;
        else Debug.Log("No ball");

        //rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerBall)
        {
            PlayerBall = FindObjectOfType<BallManager>().gameObject;
        }
        else { return; }

        if (PlayerBall)
        {

            //transform.up = PlayerBall.transform.position - transform.position;
            //rb.AddRelativeForce(-transform.up * (moveSpeed * 10) * Time.deltaTime);
            
        }
        else
        {

        }
        navMesh.SetDestination(PlayerBall.transform.position);
    }
}
