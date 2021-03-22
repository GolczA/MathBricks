using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delegate : MonoBehaviour
{
    public delegate void PuttBttn();
    
    public TextProba text1;
    public TextProba text2;
    public Sphere sphere1; 

    public void Awake()
    {
        ControlDelgate.PuttBttnEvent += text1.ChangeText; 
        ControlDelgate.PuttBttnEvent += text2.ChangeText;
        ControlDelgate.PuttBttnEvent += sphere1.Teleport;

        Sphere.ReturnPosition += sphere1.ResetPosition;
    }
}
