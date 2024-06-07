using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitRivalManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerBall;
    NavMeshAgent navMesh;
    

    [Header("Values")]
    [SerializeField] private float moveSpeed;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        
    }

    
    void Update()
    {
        

        if (PlayerBall)
        {

            transform.up = PlayerBall.transform.position - transform.position;
            
            navMesh.SetDestination(PlayerBall.transform.position);
            
        }
        if (!PlayerBall)
        {

            PlayerBall = FindObjectOfType<BallManager>().gameObject;
            if (!PlayerBall)
            {
                transform.position = transform.position;
            }
        }
        
        
    }
}
