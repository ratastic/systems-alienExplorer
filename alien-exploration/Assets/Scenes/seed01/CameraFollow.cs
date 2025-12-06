using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5f; // how far away from the target
    public float mouseSensitivity = 5f;
    public float minYAngle = 10f; // clamp vertical angle
    public float maxYAngle = 60f; // clamp horizontal angle

    private float yaw = 0f; // rotation around Y axis ; left right movement
    private float pitch = 20f; // rotation around X axis ; up down movement

    public float viewOffset = 5f; // offset so that target object isn't smack in the center

    void LateUpdate()
    {
        if (!target) return;

        // read mouse movement
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // clamp rotation around x axis so camera doesn't flip
        pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);

        // calculate rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // defines camera position in relation to the target object
        Vector3 desiredPos = target.position - (rotation * Vector3.forward * distance);
        transform.position = desiredPos;

        // always look at target object 
        transform.LookAt(target.position + Vector3.up * viewOffset);
    }
}
