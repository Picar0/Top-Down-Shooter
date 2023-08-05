using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    private Vector3 offset;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - _target.transform.position;
    }

    void LateUpdate()
    {
        transform.position = _target.transform.position + offset;
    }
}

