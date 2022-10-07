using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class RecordStatus : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void UpdatePlayStatus()
    {
        anim.SetBool("isPaused", true);
        anim.SetBool("isPlaying", true);
    }

}
