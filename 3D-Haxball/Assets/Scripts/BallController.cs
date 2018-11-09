using UnityEngine;

public class BallController : MonoBehaviour {

    public static BallController instance;
    private RoomManager _roomManager;

    private Rigidbody _rb;
    private Transform _startPosition;

    private void Awake() {
        if (instance == null)
            instance = this;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _roomManager = RoomManager.instance;
        _startPosition = transform;
    }

    public void ApplyForce(PlayerController playerController, Vector3 direction, float force, float kickDistance) {
        _rb.AddForce(direction.normalized * force * Mathf.Pow(kickDistance, -1));
    }

    public Transform GetStartPosition() {
        return _startPosition;
    }

}
