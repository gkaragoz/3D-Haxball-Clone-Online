using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour { 

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
    }

}    