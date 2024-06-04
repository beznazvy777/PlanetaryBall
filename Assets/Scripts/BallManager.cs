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
    
    

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void Update() {
        if (rigidbody.velocity.x > 0 && rigidbody.velocity.y > 0) {
            
            //rigidbody.drag += angularPower * Time.deltaTime;
            
        }
        
    }

    public void OnMouseDown() {
        
        
        //rigidbody.velocity = new Vector2(0f, 0f);
        //rigidbody.drag = 0f;
        

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
