using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;
    private PlayerController _playerController;

    private void Start() {
        _animator = GetComponentInChildren<Animator>();
        _playerController = GetComponent <PlayerController>();
    }

    private void Update() {
        if (_playerController == null || _playerController.enabled == false)
            return;

        _animator.SetFloat("Velocity", _playerController.GetVelocity());
    }

    public void Shot() {
        _animator.SetTrigger("Shot");
    }
}
