using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBttn : MonoBehaviour
{
    public Sprite soundOffSprite;
    public Sprite soundOnSprite;

    public void Start()
    {
        if (MainData.isSoundOn == true) gameObject.GetComponent<Image>().sprite = soundOnSprite;
        else gameObject.GetComponent<Image>().sprite = soundOffSprite; 
    }
}
