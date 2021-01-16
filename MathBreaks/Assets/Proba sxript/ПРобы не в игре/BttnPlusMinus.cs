using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BttnPlusMinus : MonoBehaviour
{
    Text score;
    int scR;

    private void Start()
    {
        scR = 1;
        score = gameObject.GetComponent<Text>();
        score.text = scR.ToString();
    }
    private void Update()
    {
        score.text = scR.ToString();
        Debug.Log("VVV");
    }

    public void Plus()
    {
        scR += 1; 
    }

    public void Minus()
    {
        scR -= 1; 
    }
}

