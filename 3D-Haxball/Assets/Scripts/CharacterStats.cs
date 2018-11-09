using UnityEngine;

public class CharacterStats : MonoBehaviour {

    [SerializeField]
	private float _movementSpeed;

    [SerializeField]
    private float _currentSpeed;

    [SerializeField]
    private float _kickForce;

    public float MovementSpeed {
        get {
            return _movementSpeed;
        }

        set {
            _movementSpeed = value;
        }
    }

    public float CurrentSpeed {
        get {
            return _currentSpeed;
        }

        set {
            _currentSpeed = value;
        }
    }

    public float KickForce {
        get {
            return _kickForce;
        }

        set {
            _kickForce = value;
        }
    }
}
