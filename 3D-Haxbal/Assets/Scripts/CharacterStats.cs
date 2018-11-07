using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public float _movementSpeed; //sonrasında private olabilir
    public float _kickForce;  //sonrasında private olabilir

    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }

        set
        {
            _movementSpeed = value;
        }
    }

    public float KickForce
    {
        get
        {
            return _kickForce;
        }

        set
        {
            _kickForce = value;
        }
    }

	
}
