using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextProba : MonoBehaviour
{
    private Text tx;
    //GameObject dontDestr;

    private void Start()
    {
        tx = GetComponent<Text>();
        //dontDestr = GameObject.FindGameObjectWithTag("Wood");
        //tx.text = dontDestr.GetComponent<DontDestroyProba>().numberMass.ToString();
    }


}
