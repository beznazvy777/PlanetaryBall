using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    public Transform ballTransform;
    void Start()
    {
        if(ballTransform == null) {
            transform.position = ballTransform.position;
        }
    }

    
    void Update()
    {
        transform.position = ballTransform.position;
    }
}
