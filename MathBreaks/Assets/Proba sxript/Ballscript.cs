
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour
{
    public void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().mass = MainData.bullMass;
  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gameObject.SetActive(false);
        }
    }

    
}
