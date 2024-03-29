using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Recording
{
    public ReplayObject replayObject { get; private set; }
    private Queue<ReplayData> originalQueue;
    private Queue<ReplayData> replayQueue;
    private bool replayPaused;

    public Recording(Queue<ReplayData> recordingQueue)
    {
        this.originalQueue = new Queue<ReplayData>(recordingQueue);
        this.replayQueue = new Queue<ReplayData>(recordingQueue);
    }

    public void RestartFromBeginning()
    {
        this.replayQueue = new Queue<ReplayData>(originalQueue);
    }

    public bool PlayNextFrame()
    {
        // Checks if the replay is null
        if (replayObject == null)
        {
            Debug.Log("Tried playing next frame but replayObject was null");
        }

        bool hasMoreFrames = false;
        if (replayQueue.Count != 0)
        {
            ReplayData data = replayQueue.Dequeue();
            replayObject.SetDataForFrame(data);
            hasMoreFrames = true;
        }

        return hasMoreFrames;
    }

    public void InstantiateReplayObject(GameObject replayObjectPrefab)
    {
        if (replayQueue.Count != 0)
        {
            ReplayData startingData = replayQueue.Peek();
            this.replayObject = Object.Instantiate(replayObjectPrefab, startingData.position, quaternion.identity)
                .GetComponent<ReplayObject>();
            replayObject.GetComponent<BoxCollider2D>().enabled = true;
            replayObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void DestroyReplayObjectIfExists()
    {
        if (replayObject != null)
        {
            Object.Destroy(replayObject.gameObject);
        }
    }
}
