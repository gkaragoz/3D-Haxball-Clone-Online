using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;
    private PlayerController _playerController;

    private void Start() {
        _animator = GetComponentInChildren<Animator>();
        _playerController = GetComponent <PlayerController>();
    }

    private void Update() {
        _animator.SetFloat("Velocity", _playerController.GetVelocity());
    }

    public void Shot() {
        _animator.SetTrigger("Shot");
    }
}
