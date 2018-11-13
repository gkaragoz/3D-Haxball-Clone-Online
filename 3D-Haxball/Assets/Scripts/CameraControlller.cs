using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour {

    #region Singleton

    public static CameraControlller instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    public float smooth = 1.5f;
    public Vector3 offset;

    private Transform _ballTransform;
    private Transform _playerTransform;

    private void Start() {
        _ballTransform = GameObject.Find("Ball").transform;
    }

    private void FixedUpdate() {
        if (_ballTransform == null || _playerTransform == null)
            return;

        Move();
    }

    public void Move() {
        transform.position = Vector3.Slerp(transform.position, _playerTransform.position + offset, smooth * Time.deltaTime);
    }

    public void SetTarget(Transform playerTarget) {
        _playerTransform = playerTarget;
    }

}    
