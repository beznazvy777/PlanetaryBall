using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    [SerializeField] private float speedRotate;
    [SerializeField] private float stopSpeedValue;

    Quaternion startBallRotation;
    BallManager ballManager;
    void Start()
    {
        ballManager = GetComponentInParent<BallManager>();
        ballManager.OnRotateInHit += BallManager_OnRotateInHit;
        startBallRotation = transform.rotation;
    }

    private void BallManager_OnRotateInHit(object sender, System.EventArgs e) {
        StartCoroutine("RotateTheBall");
    }

    // Update is called once per frame
    public IEnumerator RotateTheBall() {
        transform.rotation = startBallRotation;
        float time = Random.RandomRange(1, 2);
        float rotateSpeed = time;
        for (float t = 0; t < time; t+=Time.deltaTime) {
            
            transform.Rotate(Vector3.Slerp(new Vector3(0f,0f,0f), new Vector3(0f, 0f, 1080f), rotateSpeed/stopSpeedValue * Time.deltaTime));
            

            yield return null;
        }
       
    }
}
