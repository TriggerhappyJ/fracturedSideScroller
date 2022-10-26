using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private Vector3 closedPosition;
    [SerializeField] private Vector3 openDistance;
    [SerializeField] private float openSpeed;
    private bool opening;

    public void Open()
    {
        opening = true;
    }


    public void Close()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        opening = false;
    }

    private void Update()
    {
        if (opening)
        {
            transform.localPosition = Vector3.Slerp(closedPosition, openDistance, Time.deltaTime*openSpeed);
        }
        else if (!opening)
        {
            transform.localPosition = Vector3.Slerp(openDistance, closedPosition , Time.deltaTime*openSpeed);
        }
    }
}
