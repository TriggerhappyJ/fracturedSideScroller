using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordStatus : MonoBehaviour
{
    [SerializeField] private Sprite stopped, recording, play, paused;
    [SerializeField] public Image image;

    public void ChangeImage(int state)
    {
        if (state == 1)
        {
            image.sprite = play;
        }
    }
}
