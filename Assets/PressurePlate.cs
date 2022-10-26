using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent pressureEnter;
    [SerializeField] private UnityEvent pressureExit;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pressureEnter.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        pressureExit.Invoke();
    }
}
    
