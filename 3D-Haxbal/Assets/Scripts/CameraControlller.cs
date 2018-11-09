using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour { 

<<<<<<< HEAD
    public List<Transform> allTargets = new List<Transform>();
    public Vector3 offset;

    public float smoothTime = .5f;
    public Vector3 velocity;

    private Camera _cam;

    private void Start() {
        _cam = GetComponent<Camera>();
    }

    private void LateUpdate() {
        if (allTargets.Count == 0)
            return;

        Move();
    }

    private void Move() {
        Vector3 centerPoint = GetCenterPoint();

        float additionalY = centerPoint.x;
        float additionalZ = centerPoint.z;
        Vector3 additionalVector = new Vector3(0f, additionalY, additionalZ);

        Vector3 newPosition = centerPoint + offset + additionalVector;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    private float GetGreatestDistance() {
        var bounds = new Bounds(allTargets[0].position, Vector3.zero);
        for (int ii = 0; ii < allTargets.Count; ii++) {
            bounds.Encapsulate(allTargets[ii].position);
        }

        return bounds.size.magnitude;
    }

    private Vector3 GetCenterPoint() {
        if (allTargets.Count == 1) {
            return allTargets[0].position;
        }

        var bounds = new Bounds(allTargets[0].position, Vector3.zero);
        for (int ii = 0; ii < allTargets.Count; ii++) {
            bounds.Encapsulate(allTargets[ii].position);
        }

        return bounds.center;
=======
    public Transform transform1;
    public Transform transform2;

    public  float smooth = 0.8f;

    public GameObject Cam;

    private void LateUpdate()
    {
        Zoom();
    }

    private void Zoom()
    {
        Vector3 midpoint = (transform1.position + transform2.position) / 2f;
        float distance = (transform1.position - transform2.position).magnitude;

        Vector3 cameraDestination = midpoint - transform.forward * distance * zoomFactorFinder(distance);

        cameraDestination.x = transform.position.x;
        transform.position = Vector3.Slerp(transform.position, cameraDestination, smooth * Time.deltaTime);
     
        var targetRotation = Quaternion.LookRotation(midpoint - Cam.transform.position);

        Cam.transform.rotation = Quaternion.Slerp(Cam.transform.rotation, targetRotation, smooth * Time.deltaTime);
    }
    public float zoomFactorFinder(float distance)
    {
        return -0.0455f * distance + 3.13636f;//elle hesaplandı değiştirlebilir https://keisan.casio.com/exec/system/1223508685
>>>>>>> 72738b6854dcf22502b32a30873dd5b36ba1fd20
    }
}    