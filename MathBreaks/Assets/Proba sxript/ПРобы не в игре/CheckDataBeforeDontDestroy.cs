using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDataBeforeDontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().mass = 1000;
        gameObject.transform.position = new Vector3(0, 500, 0); 
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().mass += 10;
        Debug.Log(gameObject.GetComponent<Rigidbody2D>().mass);
    }
}
