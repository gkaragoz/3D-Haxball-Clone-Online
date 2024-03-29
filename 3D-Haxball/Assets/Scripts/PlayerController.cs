﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public Player player;

    public float shootRange = 3f;
    public bool isShoting = false;
    public float stoppingTime = 0.5f;
    public const float slowingSpeedMultiplier = .75f;

  
    [SerializeField]
    private float _maxShotMultiplier;
  
    private Rigidbody _rb;
    private BallController _ballController;

    private PlayerAnimation _playerAnimation;
    private Transform _startPosition;

    private PlayerHUD _playerHUD;

    void Start () {
        _rb = GetComponent<Rigidbody>();
        _ballController = FindObjectOfType<BallController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _startPosition = transform;
        _playerHUD = GetComponentInChildren<PlayerHUD>();

      
        _maxShotMultiplier = 10f;
      
        player.CurrentSpeed = player.MovementSpeed;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ApplySlowMovement();
            _playerHUD.EnableAim();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _playerHUD.UpdateAim(GetAngleOfBall());
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            ResetSpeed();
            Shot();
        }
    }

    private void FixedUpdate() {
        Vector2 input = GetInputAxis();

        if (isShoting) {
            return;
        }

        Rotate(input);
        Move(input);
    }

    private void ApplySlowMovement() {
        player.CurrentSpeed *= slowingSpeedMultiplier;
    }

    private void ResetSpeed() {
        player.CurrentSpeed = player.MovementSpeed;
    }

    private Vector2 GetInputAxis() {
        return new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"),
                            CrossPlatformInputManager.GetAxisRaw("Vertical"));
    }

    private void Move(Vector2 axis) {
        Vector3 moveVec = new Vector3(axis.x, 0, axis.y) * player.CurrentSpeed;
        _rb.velocity = moveVec;
    }

    private void Rotate(Vector2 axis) {
        if (axis != Vector2.zero) {
            float rotationAngle = Mathf.Atan2(axis.x, axis.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * rotationAngle;
        }
    }

    private void Stop() {
        _rb.velocity = Vector3.zero;
    }
         
    private void Shot() {
        Vector3 ballPosition = _ballController.transform.position;

        if (BeAbleToShot(transform.position, ballPosition)) {
            Vector3 shootDirection = ballPosition - transform.position;
            float kickDistance = GetDistanceOfBall();

            _ballController.ApplyForce(this, shootDirection, player.KickForce * _maxShotMultiplier, kickDistance);
        }

        Invoke("Stop", stoppingTime);
        isShoting = true;
        _playerHUD.DisableAim();
        _playerAnimation.Shot();
    }

    public Transform GetAngleOfBall() {
      //  Vector3 targetDir = _ballController.transform.position - transform.localPosition;
      //  float angle = Vector3.Angle(targetDir, transform.forward);

   
        return _ballController.transform;
    }

    public float GetDistanceOfBall() {
        return Vector3.Distance(transform.position, _ballController.transform.position);
    }

    public bool BeAbleToShot(Vector3 playerPosition, Vector3 targetPosition) {
        float distance = GetDistanceOfBall();

        if (distance > shootRange)
            return false;

        return true;
    }
    
    public float GetVelocity() {
        return _rb.velocity.magnitude;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
