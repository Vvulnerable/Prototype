using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFacing : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1.5f, -4f);

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the new position based on the target's rotation
            Vector3 rotatedOffset = target.rotation * offset;

            // Update the camera's position and rotation
            transform.position = target.position + rotatedOffset;
            transform.LookAt(target);
        }
    }
}
