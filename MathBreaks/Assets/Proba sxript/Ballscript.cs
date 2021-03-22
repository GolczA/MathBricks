
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour
{
    private AudioSource bangAudio;
    public ParticleSystem partSystem; 
    public void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().mass = MainData.bullMass;
        bangAudio = GetComponent<AudioSource>();
        //var em = partSystem.emission; увеличить количество частиц может пригодится увеличить при увеличении скорости
        //em.burstCount = 15;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Snow" && MainData.isSoundOn)
        {
            bangAudio.Play();
            partSystem.Play();
        }
        if (collision.gameObject.tag == "Brick" && MainData.isSoundOn)
        {
            bangAudio.Play();
            partSystem.Play();
        }
        if (collision.gameObject.tag == "Clay" && MainData.isSoundOn)
        {
            bangAudio.Play();
            partSystem.Play();
        }
        if (collision.gameObject.tag == "Stone" && MainData.isSoundOn)
        {
            bangAudio.Play();
            partSystem.Play();
        }
        if (collision.gameObject.tag == "Wood" && MainData.isSoundOn)
        {
            bangAudio.Play();
            partSystem.Play();
        }
    }

    
}
