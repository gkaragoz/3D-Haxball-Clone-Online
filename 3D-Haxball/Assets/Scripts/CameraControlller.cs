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
    public float xMultiplier = -0.5f;
    public float offset = 35f;

    private Transform _ballTransform;
    private Transform _playerTransform;

    private void Start() {
        _ballTransform = GameObject.Find("Ball").transform;
    }

    private void LateUpdate() {
        if (_ballTransform == null || _playerTransform == null)
            return;

        Move();
    }

    public void Move() {
        Vector3 midpoint = (_ballTransform.position + _playerTransform.position) * 0.5f;
        float distance = Vector3.Distance(_ballTransform.position, _playerTransform.position);

        Vector3 desiredDestination = midpoint - transform.forward * ZoomFactorFinder(_ballTransform.transform.position.z);

        desiredDestination.x = transform.position.x;

        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, new Vector3(-1f * _ballTransform.transform.position.z + 40f, 0f, 0f), smooth * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, desiredDestination, smooth * Time.deltaTime);
    }

    public float ZoomFactorFinder(float distance) {
        return xMultiplier * distance + offset; //ref https://keisan.casio.com/exec/system/1223508685
    }

    public void SetTarget(Transform playerTarget) {
        _playerTransform = playerTarget;
    }

}    
