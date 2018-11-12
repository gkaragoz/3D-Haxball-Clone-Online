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

    private GameObject _target;
    private GameObject _player;

   
    private void Start() {
        _target = GameObject.Find("Ball");
    }

    private void LateUpdate() {
        Zoom();
    }

    private void Zoom() {
        if (_target == null || _player == null)
            return;

        Vector3 midpoint = (_target.transform.position + _player.transform.position) / 2f;
        float distance = (_target.transform.position - _player.transform.position).magnitude;

        Vector3 cameraDestination = midpoint - transform.forward * zoomFactorFinder(distance);

        cameraDestination.x = transform.position.x;
        transform.position = Vector3.Slerp(transform.position, cameraDestination, smooth * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(midpoint - Camera.main.transform.position);

        Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRotation, smooth * Time.deltaTime);
    }

    public float zoomFactorFinder(float distance) {
   
        //(10,20) (50,30) noktalrında geçen doğru denklemi
        if (distance > 50)
            return 30f;
        if (distance < 10)
            return 20;
        else
            return 0.25f * distance + 17.5f; //ref https://keisan.casio.com/exec/system/1223508685
    }

    public void SetTarget(GameObject playerTarget) {
        _player = playerTarget;
    }

}    
