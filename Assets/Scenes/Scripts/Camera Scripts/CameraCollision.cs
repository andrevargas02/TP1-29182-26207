using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 3.0f;
    public Vector3 offset;
    public float collisionBuffer = 0.3f; // Espaço extra para evitar colisão visual com a parede

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        RaycastHit hit;

        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, distanceFromTarget))
        {
            transform.position = hit.point - (hit.normal * collisionBuffer);
        }
        else
        {
            transform.position = desiredPosition;
        }
    }
}