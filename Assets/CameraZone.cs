using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    private Transform cameraAngle;
    [SerializeField] private float changeSpeed = 8f;

    private void Awake()
    {
        cameraAngle = transform;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Camera.main.transform.SetPositionAndRotation(Vector3.Lerp(Camera.main.transform.position,cameraAngle.transform.position, Time.deltaTime*changeSpeed), cameraAngle.transform.rotation);
        }
    }
}
