using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerManager : MonoBehaviour {

    Rigidbody rigidbody;
    public float speed = 2;
    private float cachedPlayerAngle;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        cachedPlayerAngle = transform.eulerAngles.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float myAngle = Mathf.Atan2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * Mathf.Rad2Deg;
        float lerpangle = Mathf.LerpAngle(cachedPlayerAngle, myAngle, Time.deltaTime * 10);
        cachedPlayerAngle = lerpangle;
        transform.eulerAngles = new Vector3(0, lerpangle, 0);

        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),0, CrossPlatformInputManager.GetAxis("Vertical")) * speed;
        rigidbody.velocity=moveVec;

    }
}
