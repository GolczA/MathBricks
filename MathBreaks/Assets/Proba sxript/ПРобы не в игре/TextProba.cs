using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextProba : MonoBehaviour
{
    private Text tx;


    private void Start()
    {
        tx = gameObject.GetComponent<Text>();
    }

    public void ChangeText()
    {
        tx.text = "Ура, мы заебенили делегат !!! ";
    }


}
