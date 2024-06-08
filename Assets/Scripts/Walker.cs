using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Transform ballTransform;
    void Start()
    {
        if(!ballTransform) {
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
            transform.position = ballTransform.position;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
