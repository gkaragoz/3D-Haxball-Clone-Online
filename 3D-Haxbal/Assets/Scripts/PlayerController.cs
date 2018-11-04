using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 2f;
    public float shootRange = 3f;

    public float minLaunchForce = 5f;       
    public float maxLaunchForce = 15f;      
    public float maxChargeTime = 0.75f;

    private Rigidbody _rb;
    private BallController _ballController;
    private float _cachedPlayerAngle;
    private float _currentLaunchForce;
    private float _chargeSpeed;                
    private bool _isFired;

    void Start () {
        _rb = GetComponent<Rigidbody>();
        _ballController = BallController.instance;
        _chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

        _currentLaunchForce = minLaunchForce;
        UIManager.instance.aimSlider.value = minLaunchForce;
    }

    void FixedUpdate() {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        Rotate(horizontal, vertical);
        Move(horizontal, vertical);

        UIManager.instance.aimSlider.value = minLaunchForce;

        if (_currentLaunchForce >= maxLaunchForce && !_isFired) {
            _currentLaunchForce = maxLaunchForce;
            Shoot();
        } else if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            _isFired = false;
            _currentLaunchForce = minLaunchForce;
            //Play shoot audio.
        } else if (CrossPlatformInputManager.GetButton("Jump") && !_isFired) {
            _currentLaunchForce += _chargeSpeed * Time.deltaTime;
            UIManager.instance.aimSlider.value = _currentLaunchForce;
        } else if (CrossPlatformInputManager.GetButtonUp("Jump") && !_isFired) {
            Shoot();
        }
    }

    private void Move(float horizontal, float vertical) {
        Vector3 moveVec = new Vector3(horizontal, 0, vertical) * movementSpeed;
        _rb.velocity = moveVec;
    }

    private void Rotate(float horizontal, float vertical) {
        if (horizontal != 0 || vertical != 0) {
            float myAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            float lerpangle = Mathf.LerpAngle(_cachedPlayerAngle, myAngle, Time.deltaTime * 10);
            _cachedPlayerAngle = lerpangle;
            transform.eulerAngles = new Vector3(0, lerpangle, 0);
        }
    }

    private void Shoot() {
        Vector3 ballPosition = _ballController.transform.position;
        Vector3 playerPosition = transform.position;

        if (IsReadyForShoot(playerPosition, ballPosition)) {
            Vector3 shootDirection = ballPosition - playerPosition;
            float kickDistance = GetDistanceOfBall();

            _ballController.ApplyForce(shootDirection, _currentLaunchForce, kickDistance);
        }

        _currentLaunchForce = minLaunchForce;
    }

    public float GetDistanceOfBall() {
        return Vector3.Distance(transform.position, _ballController.transform.position);
    }

    public bool IsReadyForShoot(Vector3 playerPosition, Vector3 targetPosition) {
        float distance = GetDistanceOfBall();

        if (distance > shootRange)
            return false;

        return true;
    }
}
