using UnityEngine;

public class CharacterStats {

    [Header("Character Stats")]
    [SerializeField]
	private float _movementSpeed;
    [SerializeField]
    private float _currentSpeed;
    [SerializeField]
    private float _kickForce;

    public float MovementSpeed {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    public float CurrentSpeed {
        get { return _currentSpeed; }
        set { _currentSpeed = value; }
    }

    public float KickForce {
        get { return _kickForce; }
        set { _kickForce = value; }
    }

    public CharacterStats(float movementSpeed, float currentSpeed, float kickForce) {
        this.MovementSpeed = movementSpeed;
        this.CurrentSpeed = currentSpeed;
        this.KickForce = kickForce;
    }

}
