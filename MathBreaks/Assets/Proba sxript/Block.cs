using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D rb;
    bool isStay;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rb.velocity == new Vector2(0, 0))
        {
           isStay = true;
        }
        else isStay = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyLine" || collision.gameObject.tag == "DestroyLine2")
        {
            Destroy(gameObject);
        }
    }


}
