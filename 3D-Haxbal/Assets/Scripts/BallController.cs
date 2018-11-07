using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static BallController instance;
    private RoomManager _roomManager;

    private PlayerController sonplayer;
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

        _rb.AddForce(direction * force * (3.0f / kickDistance));
        sonplayer = playerController;
    }


    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            sonplayer = other.gameObject.GetComponent<PlayerController>();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalPost1")
        {
            _roomManager.Goal(sonplayer,1);
        }
        if (other.gameObject.tag == "GoalPost2")
        {
            _roomManager.Goal(sonplayer,2);
        }
    }
    public void SetStartPosition()
    {
        transform.position = _startPosition.position;
        transform.rotation = _startPosition.rotation;
    }
}
