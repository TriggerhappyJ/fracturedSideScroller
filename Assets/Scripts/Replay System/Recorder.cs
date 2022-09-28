using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [Header("Prefab to Instantiate")]
    [SerializeField] private GameObject replayObjectPrefab;
    
    public Queue<ReplayData> recordingQueue { get; private set; }

    private Recording recording;
    
    // Checks if replay is active
    private bool isDoingReplay = false;

    private void Awake()
    {
        // Creates a new queue to hold replay data
        recordingQueue = new Queue<ReplayData>();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            StartReplay();
            Debug.Log("Attempting replay");
        }
        
        if (Input.GetButtonUp("Cancel"))
        {
            Reset();
        }

        if (!isDoingReplay)
        {
            return;
        }

        bool hasMoreFrames = recording.PlayNextFrame();

        // Check is replay is finished
        if (!hasMoreFrames)
        {
            //RestartReplay();
            Reset();
        }
        
    }

    public void RecordReplayFrame(ReplayData data)
    {
        recordingQueue.Enqueue(data);
    }

    private void StartReplay()
    {
        isDoingReplay = true;
        
        // initialize recording
        recording = new Recording(recordingQueue);
        
        // Clear queue
        recordingQueue.Clear();
        
        // instantiate replay object
        recording.InstantiateReplayObject(replayObjectPrefab);

    }

    /*private void RestartReplay()
    {
        isDoingReplay = true;
        // Restart replay
        recording.RestartFromBeginning();
    }*/

    private void Reset()
    {
        isDoingReplay = false;
        // Clean up recorder
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfExists();
        recording = null;
        Debug.Log("Resetting replay data");
    }
    
}