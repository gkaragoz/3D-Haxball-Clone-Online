using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModels : MonoBehaviour {

    public float sensitivity = 20.0f;
    private Transform _CameraTransform;

    void Start()
    {

        _CameraTransform = Camera.main.transform;
        
    }
    private void OnMouseDrag()
    {
        float rotationX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(_CameraTransform.up, -rotationX, Space.World);
      
    }
 
    void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime*sensitivity);
    }
}
