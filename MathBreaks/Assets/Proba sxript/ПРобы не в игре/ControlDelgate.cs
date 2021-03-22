using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDelgate : MonoBehaviour
{
    public static event Delegate.PuttBttn PuttBttnEvent;

    public void OnMouseDown()
    {
        PuttBttnEvent(); 
    }
}
