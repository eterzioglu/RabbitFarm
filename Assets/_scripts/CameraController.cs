using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;

    public void SetOffset(Transform target)
    {
        _offset = transform.position - target.position;
    }

    public void FollowTarget(Transform target)
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.y = transform.position.y;
        transform.position = targetPosition;
    }
}
