using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float angularPower;
    private Vector2 rbVelocity;



    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void Update() {
        rbVelocity = rigidbody.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            

            var rbVelocityValue = rbVelocity.magnitude;
            var direction = Vector2.Reflect(rbVelocity.normalized, collision.contacts[0].normal);

            rigidbody.velocity = direction * Mathf.Max(rbVelocityValue, 0f);

            

            

        }


    }

    public void OnMouseDrag() {
        Vector2 touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 position = Camera.main.ScreenToWorldPoint(touchPosition);

        transform.LookAt(position);
        
    }

    public void OnMouseUp() {

        rigidbody.AddRelativeForce(transform.forward * forwardSpeed * 10 * Time.deltaTime);

        

    }


}
