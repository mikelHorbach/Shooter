﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 cam = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, cam , smoothing*Time.deltaTime);
    }
}
