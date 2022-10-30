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
    private bool isDoingReplay;
    private bool replayPaused;
    private bool hasMoreFrames;

    [SerializeField] private Animator statusAnim;
    
    private void Awake()
    {
        // Creates a new queue to hold replay data
        recordingQueue = new Queue<ReplayData>();
    }

    private void Update()
    {
        statusAnim.SetBool("isPlaying", isDoingReplay);
        statusAnim.SetBool("isPaused", replayPaused);
        // Starts Replay
        if (Input.GetKeyUp("e"))
        {
            if (replayPaused == false && !isDoingReplay)
            {
                StartReplay();
                Debug.Log("Attempting replay");
            }
            else 
            {
                replayPaused = !replayPaused;
                Debug.Log("Pausing Replay");
                this.recording.replayObject.GetComponent<BoxCollider2D>().enabled = replayPaused;
                if (replayPaused)
                {
                    this.recording.replayObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.01f, 0f);
                }
                else
                {
                    this.recording.replayObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                }

                this.recording.replayObject.GetComponent<Animator>().enabled = !replayPaused;
            }
        }

        if (!isDoingReplay)
        {
            return;
        }

        // Plays next frames of replay if not paused
        if (!replayPaused)
        {
            hasMoreFrames = recording.PlayNextFrame();
        }

        // Check is replay is finished
        if (!hasMoreFrames)
        {
            RestartReplay();
            //Reset();
        }
        
    }

    public void RecordReplayFrame(ReplayData data)
    {
        if (replayPaused)
        {
            Reset();
        }
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

    private void RestartReplay()
    {
        isDoingReplay = true;
        // Restart replay
        recording.RestartFromBeginning();
    }

    public void Reset()
    {
        replayPaused = false;
        // Clean up recorder
        recordingQueue.Clear();
        if (isDoingReplay)
        {
            recording.DestroyReplayObjectIfExists();
        }
        isDoingReplay = false;
        recording = null;
        Debug.Log("Resetting replay data");
    }

    
}