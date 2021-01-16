using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lngbttn : MonoBehaviour
{
    public Sprite english;
    public Sprite russian;

    public void Awake()
    {
        MainData.isEnglish = true;
    }
    public void Start()
    {
        if (MainData.isEnglish == true) gameObject.GetComponent<Image>().sprite = english;
        else gameObject.GetComponent<Image>().sprite = russian;
    }
}
