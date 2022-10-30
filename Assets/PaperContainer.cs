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

    // Draw hearts on screen and set them to correct sprite (half heart, full heart etc)
    private void DrawPaper()
    {
        // Create current hearts based of current health
        for(var i = 0; i < _papers.Count; i++)
        {
            var paperStatusRemainder = (float)Mathf.Clamp(ItemManager.paperCount - (i*2), 0, 2) + 0.99f;
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

    // Remove all hearts
    private void ClearPaper()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
            _papers = new List<Paper>();
        }
    }

    // Draw hearts on startup
    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
            
        ClearPaper();

        // Create all hearts to be empty before adding full ones based off max health
        for(var i = 0; i < (int)paperCount; i++)
        {
            FullPaper();
        }
            
        DrawPaper();
    }

    public void incrementPaperCount()
    {
        paperCount++;
        DrawPaper();
    }
}

