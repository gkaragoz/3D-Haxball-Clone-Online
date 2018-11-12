using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody _rb;
    private Transform _startPosition;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform;
    }

    public void ApplyForce(PlayerController playerController, Vector3 direction, float force, float kickDistance) {
        _rb.AddForce(direction.normalized * force * Mathf.Pow(kickDistance, -1));
    }

    public Transform GetStartPosition() {
        return _startPosition;
    }

}
