using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    private float _movementSpeed;
    private float _kickForce;


    public string Name;
    public int FormaNo;
    public int TakimNo;


    public float shootRange = 3f;

    public float minLaunchForce = 5f;       
    public float maxLaunchForce = 15f;      
    public float maxChargeTime = 0.75f;

    private Rigidbody _rb;
    private BallController _ballController;
    private Transform _footPoint;
    private float _cachedPlayerAngle;
    private float _currentLaunchForce;
    private float _chargeSpeed;                
    private bool _isFired;
    private PlayerAnimation _playerAnimation;
    private CharacterStats _characterStats;

    private Transform _startPosition;

    public Slider aimSlider;

    void Start () {
        _rb = GetComponent<Rigidbody>();
        _ballController = BallController.instance;
        _footPoint = transform.Find("FootPoint");
        _chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _characterStats = GetComponent<CharacterStats>();
        _currentLaunchForce = minLaunchForce;

        _movementSpeed = _characterStats.MovementSpeed;
        _kickForce = _characterStats.KickForce;

        //  UIManager.instance.aimSlider.value = minLaunchForce;
        aimSlider.value = minLaunchForce;
        _startPosition = transform;
    }

    void FixedUpdate() {
        Vector2 input = GetInputAxis();

        Rotate(input);
        Move(input);

        //.instance.aimSlider.value = minLaunchForce;

        if (_currentLaunchForce >= maxLaunchForce && !_isFired) {
            _currentLaunchForce = maxLaunchForce;
            Shoot();
        } else if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            _isFired = false;
            _currentLaunchForce = minLaunchForce;
            //Play shoot audio.
        } else if (CrossPlatformInputManager.GetButton("Jump") && !_isFired) {
            _currentLaunchForce += _chargeSpeed * Time.deltaTime;
            aimSlider.value = _currentLaunchForce;
        } else if (CrossPlatformInputManager.GetButtonUp("Jump") && !_isFired) {
            Shoot();
        }
    }

    private Vector2 GetInputAxis() {
        return new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
                            CrossPlatformInputManager.GetAxis("Vertical"));
    }

    private void Move(Vector2 axis) {
        Vector3 moveVec = new Vector3(axis.x, 0, axis.y) * _movementSpeed;
        _rb.velocity = moveVec;
    }

    private void Rotate(Vector2 axis) {
        if (axis != Vector2.zero) {
            float myAngle = Mathf.Atan2(axis.x, axis.y) * Mathf.Rad2Deg;
            float lerpangle = Mathf.LerpAngle(_cachedPlayerAngle, myAngle, Time.deltaTime * 10);
            _cachedPlayerAngle = lerpangle;
            transform.eulerAngles = new Vector3(0, lerpangle, 0);
        }
    }

    private void Shoot() {
        Vector3 ballPosition = _ballController.transform.position;
        Vector3 footPosition = _footPoint.transform.position;

        if (IsReadyForShoot(footPosition, ballPosition)) {
            Vector3 shootDirection = ballPosition - footPosition;
            float kickDistance = GetDistanceOfBall();

            _ballController.ApplyForce(this,shootDirection, _currentLaunchForce*_kickForce, kickDistance);
        }

        _currentLaunchForce = minLaunchForce;

        _playerAnimation.Shoot();
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
    
    public float GetVelocity() {
        return _rb.velocity.magnitude;
    }
}
