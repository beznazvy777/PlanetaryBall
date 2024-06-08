using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Transform ballTransform;
    void Start()
    {
        if(!ballTransform) {
            //Shadow of player ball,find target to follow
            ballTransform = FindObjectOfType<BallManager>().transform;
            transform.position = ballTransform.position;

        }
        else {
            Destroy(gameObject);
        }
        transform.Rotate(0f, 90f, 0f);
    }

    
    void Update()
    {
        if(ballTransform)
        {

            //shadow follow to player ball
            transform.position = ballTransform.position;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
