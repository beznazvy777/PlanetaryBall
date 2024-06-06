using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float speedRotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,speedRotation * Time.deltaTime);
    }
}
