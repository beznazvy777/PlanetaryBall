using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

public class BallManager : MonoBehaviour
{

    public event EventHandler OnRotateInHit;

    public Camera mainCamera;
    [SerializeField] private GameObject ballShadowPrefab;
    [SerializeField] private GameObject spriteObject;
    [SerializeField] private GameObject dustCloudPrefab;
    
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float angularPower;

    
    Vector2 rbVelocity;
    Rigidbody2D rigidbody;
    GameManager gameManager;


    private void Awake() {
        mainCamera = Camera.main;

        //Create shadow of player ball
        GameObject newShadowObject = Instantiate(ballShadowPrefab,transform.position, Quaternion.identity);
        
    }
    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.BallEnterInGame(this.gameObject);

        
    }

    private void Update() {
        if (BallInCamera(mainCamera, this.gameObject)) {
            
        }
        else {
            Debug.Log("Ball out Camera");
            DestroyThisBall(this.gameObject);
        }
        rbVelocity = rigidbody.velocity;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            //Bounce effect when trigg obstacle object
            var rbVelocityValue = rbVelocity.magnitude;
            var direction = Vector2.Reflect(rbVelocity.normalized, collision.contacts[0].normal);

            rigidbody.velocity = direction * Mathf.Max(rbVelocityValue * 2, 0f);

            

            

        }


    }

    public void OnMouseDrag() {

        //Rotate ball to finger
        Vector2 touchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 position = Camera.main.ScreenToWorldPoint(touchPosition);

        transform.LookAt(position);
        
    }

    public void OnMouseUp() {

        //Force to moved ball
        rigidbody.AddRelativeForce(transform.forward * forwardSpeed * 10 * Time.deltaTime);

        //Rotate player ball in hit
        OnRotateInHit?.Invoke(this, EventArgs.Empty);

        //Create dust cloud effect in hit on ball
        Instantiate(dustCloudPrefab, transform.position, Quaternion.identity);

    }

    private bool BallInCamera(Camera camera,GameObject target) {


        //Checked player ball in camera view
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        var point = transform.position;

        foreach(var plane in planes) {
            if(plane.GetDistanceToPoint(point) < 0) {
                return false;
            }
        }
        return true;

    }

    public void DestroyThisBall(GameObject gameObject) {

        //Destroy old and restart new player ball 
        gameManager.RestartGameBall();
        Destroy(gameObject);
    }
}
