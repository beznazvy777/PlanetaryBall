using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTriggerManager : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Bonus object contacts sytem with ball
        if(collision.gameObject.tag == "Ball")
        {
            //Create events for bonus up game score
            Debug.Log("Bonus Object - Get");
            Destroy(gameObject);
        }
    }
}
