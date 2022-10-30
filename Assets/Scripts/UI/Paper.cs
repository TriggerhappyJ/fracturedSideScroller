using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Set values to sprites
public enum PaperStatus
{
    None,
    Full
}
    
public class Paper : MonoBehaviour
{
    public Sprite fullPaper, noPaper;
    private Image _paperImage;
        
    // Select correct sprite per paper
    public void SetPaper(PaperStatus status)
    {
        _paperImage.sprite = status switch
        {
            PaperStatus.None => noPaper,
            PaperStatus.Full => fullPaper,
            _ => _paperImage.sprite
        };
    }
        
    private void Awake() 
    {
        _paperImage = GetComponent<Image>();
    }

}
