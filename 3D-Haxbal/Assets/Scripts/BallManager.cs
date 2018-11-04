using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class BallManager : MonoBehaviour
 {
    Rigidbody ballRigidbody;
    private float kickForce = 10;



    void Start()
    {

       ballRigidbody = GetComponent<Rigidbody>();

        

    }
    void OnCollisionStay(Collision other)
    {
       // Debug.Log("denem");

        //We check to see if the surface we collided with has the tag of our hole, so we don't trigger this on any collision surface
        if (other.gameObject.tag == "Player")
        {
            //Set only the Y axis of the velocity to a custom value, while leaving the existing x/z velocities intact by using them as the input value
          //  ballRigidbody.AddForce(new Vector3(colObj.gameObject.transform.position.x, 0, colObj.gameObject.transform.position.z));

         //   Debug.Log("collider");

           // Vector3 direction = (other.transform.position - transform.position).normalized;
          //  ballRigidbody.velocity=(direction)*3;

        }
    }


}

