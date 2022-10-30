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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pressureEnter.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        pressureExit.Invoke();
    }
}
    
