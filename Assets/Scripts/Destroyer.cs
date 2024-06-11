using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    float timer;
    void Start()
    {
        
        timer = 0f;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToDestroy) 
            Destroy(gameObject);
    }
}
