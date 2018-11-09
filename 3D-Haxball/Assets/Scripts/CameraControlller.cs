using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour {

    public float smooth = 0.8f;

    private Transform _target;
    private Transform _player;

    private void Start() {
        _target = GameObject.Find("Ball").transform;
        _player = GameObject.Find("Player").transform;
    }

    private void LateUpdate() {
        Zoom();
    }

    private void Zoom() {
        Vector3 midpoint = (_target.position + _player.position) / 2f;
        float distance = (_target.position - _player.position).magnitude;

        Vector3 cameraDestination = midpoint - transform.forward * distance * zoomFactorFinder(distance);

        cameraDestination.x = transform.position.x;
        transform.position = Vector3.Slerp(transform.position, cameraDestination, smooth * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(midpoint - Camera.main.transform.position);

        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, smooth * Time.deltaTime);
    }
    public float zoomFactorFinder(float distance) {
        return -0.0455f * distance + 3.13636f; //ref https://keisan.casio.com/exec/system/1223508685
    }

}    