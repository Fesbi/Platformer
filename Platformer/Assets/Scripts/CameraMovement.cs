using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Update()
    {
        Vector3 position = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
