using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static BallController instance;

    private Rigidbody _rb;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    public void ApplyForce(Vector3 direction, float force, float kickDistance) {
        _rb.AddForce(2.0f * direction * force * (3.0f / kickDistance));
    }
}
