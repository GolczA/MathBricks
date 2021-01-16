using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    public GameObject block;
    public Vector3 mousePos;
    public Transform parent; 
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // эти 3 строки создают объект в точке клика
            mousePos = Input.mousePosition;
            //Debug.Log(mousePos);
            GameObject scroll = Instantiate(block, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 100)), Quaternion.identity, parent);
            // попробуем поменять параметр х для того что бы палец не закрывал бегунок
            Vector3 xPos = scroll.transform.position;
            scroll.transform.position = new Vector3 (- xPos.x, xPos.y, xPos.z); 
        
        }

        
    }
}
