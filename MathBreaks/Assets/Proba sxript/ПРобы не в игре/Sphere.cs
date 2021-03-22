using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Vector3 vector3Start;
    public static event Delegate.PuttBttn ReturnPosition; 

    private void Awake()
    {
        vector3Start = new Vector3(-600,1200,0);

    }
    public void Teleport()
    {
        transform.Translate(Vector3.down * 100);
        if (transform.position.y < -300)
        {
            ReturnPosition();  
        }
    }
    public void ResetPosition()
    {
        transform.position = vector3Start; 
    }

}
