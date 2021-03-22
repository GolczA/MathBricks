using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private AudioSource destroySound;
    public ParticleSystem particalSystem; 
    Rigidbody2D rb;
    bool isStay;
    SpriteRenderer spriteRender;

    private void Start()
    {
        destroySound = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyLine" || collision.gameObject.tag == "DestroyLine2")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            if (MainData.isSoundOn == true)
            {
                destroySound.Play();
            }
            StartCoroutine(DestroyObjBlock(0.17f));
            particalSystem.Play();
            Destroy(gameObject, 0.7f);
        }
    }
    IEnumerator DestroyObjBlock(float fl) // меняет размер перед тем как быть уничтоженным
    {
        for (int i = 0; i < 2; i++)
        {
            if (i % 2 == 0)
            {
                transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            if (i % 2 != 0)
            {
                transform.localScale = new Vector3(1f, 1f, 0);
            }
            yield return new WaitForSeconds(fl);
            spriteRender.color = Color.clear;
        }
        
    }
}
