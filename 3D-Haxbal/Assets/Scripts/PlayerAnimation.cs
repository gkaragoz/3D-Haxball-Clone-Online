using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;
    private PlayerController _playerController;

    private void Start() {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent <PlayerController>();
    }

    private void Update() {
        _animator.SetFloat("Velocity", _playerController.GetVelocity());
    }

    public void Shoot() {
        _animator.SetTrigger("Shoot");
    }
}
