using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperContainer : MonoBehaviour
{
    public GameObject paperPrefab;
    [SerializeField] private int paperCount = 0;
    private List<Paper> _papers = new();

    private void Awake()
    {
        paperCount = GameObject.FindGameObjectsWithTag("PaperCollectable").Length;
    }

    // Draw paper on screen and set them to correct sprite
    private void DrawPaper()
    {
        for(var i = 0; i < _papers.Count; i++)
        {
            var paperStatusRemainder = (float)Mathf.Clamp(ItemManager.paperCount - (i*2), 0, 1) + 0.99f;
            _papers[i].SetPaper((PaperStatus)paperStatusRemainder);
        }
    }

    private void FullPaper()
    {
        var newPaper = Instantiate(paperPrefab, transform, true);

        var paperComponent = newPaper.GetComponent<Paper>();
        paperComponent.SetPaper(PaperStatus.Full);
        _papers.Add(paperComponent);
    }

    // Remove all paper on ui
    private void ClearPaper()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
            _papers = new List<Paper>();
        }
    }

    // Draw paper on startup
    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
            
        ClearPaper();
        
        for(var i = 0; i < (int)paperCount; i++)
        {
            FullPaper();
        }
            
        DrawPaper();
    }

    public void incrementPaperCount()
    {
        paperCount += 2;
        DrawPaper();
    }
}

