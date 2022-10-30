using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    public static int paperCount = 0;
    public UnityEvent collectPaper;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PaperCollectable"))
        {
            Destroy(col.gameObject);
            paperCount += 2;
            Debug.Log(paperCount);
            collectPaper.Invoke();
        }
    }
}
