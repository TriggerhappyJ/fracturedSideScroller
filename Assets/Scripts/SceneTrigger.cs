using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerLoad;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            triggerLoad.Invoke();
        }
    }
}
