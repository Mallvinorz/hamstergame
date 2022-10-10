using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera targetCamera;
    float yaw, pitch;

    public Vector2 pitchMinMax = new Vector2(-30, 35);
    public Transform target;
    public float translateSpeed = 10;
    public float distance = 400;
    public float rotationSmoothTime = 0.15f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private void LateUpdate() {//berguna untuk mengubah posisi camera sesuai letak kursor mouse
        // yaw += Input.GetAxis("Mouse X") * translateSpeed;
        pitch -= Input.GetAxis("Mouse Y") * translateSpeed;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, 0), ref rotationSmoothVelocity, rotationSmoothTime);
        // Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distance;//fokus kamera ke objek player
    }
    
}
