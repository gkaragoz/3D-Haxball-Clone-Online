using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPlayerTurn : MonoBehaviour {

	public float turnSpeed = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
	}
}
