using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{

    public Transform target;
    public float smoothness = 0.2f;

    private void LateUpdate()
    {
        Move();
    }


    private void Move()
    {
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
    }

}    