using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetsroyLine : MonoBehaviour
{
    public LevelGO levelGO;
    public Rigidbody2D Snow; 
    public Rigidbody2D Wood; 
    public Rigidbody2D Clay; 
    public Rigidbody2D Brick;
    public Rigidbody2D Stone;
    int coeficent;

    private void Start()
    {
        if (gameObject.tag == "DestroyLine2") coeficent = 2;
        else coeficent = 1; 
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            levelGO.scoreNow += Snow.mass * coeficent;
            levelGO.textScore.text = levelGO.scoreNow.ToString(); 
        }
        if (collision.gameObject.tag == "Brick")
        {
            levelGO.scoreNow += Brick.mass * coeficent;
            levelGO.textScore.text = levelGO.scoreNow.ToString();
        }
        if (collision.gameObject.tag == "Clay")
        {
            levelGO.scoreNow += Clay.mass * coeficent;
            levelGO.textScore.text = levelGO.scoreNow.ToString();
        }
        if (collision.gameObject.tag == "Stone")
        {
            levelGO.scoreNow += Stone.mass * coeficent;
            levelGO.textScore.text = levelGO.scoreNow.ToString();
        }
        if (collision.gameObject.tag == "Wood")
        {
            levelGO.scoreNow += Wood.mass * coeficent;
            levelGO.textScore.text = levelGO.scoreNow.ToString();
        }
    }
    
}
