using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{

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
    }
}    