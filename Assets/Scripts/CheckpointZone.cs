using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointZone : MonoBehaviour
{
    private Transform checkpointLocation;
    private GameObject checkpoint;

    private void Awake()
    {
        checkpointLocation = gameObject.transform.GetChild(0);
        checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            checkpoint.transform.SetPositionAndRotation(checkpointLocation.transform.position, checkpointLocation.transform.rotation);
        }
    }
}
