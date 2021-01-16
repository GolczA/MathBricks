using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panelcheck : MonoBehaviour
{
    public GameObject stPoint;

    private void Update()
    {
        Debug.Log((stPoint.transform.position).ToString());
    }

}
