using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyProba : MonoBehaviour
{

    public int fackincount; 
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainData");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            Debug.Log($"этот объект уничтожен --- {fackincount}");
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        fackincount += 10;
    }


}
