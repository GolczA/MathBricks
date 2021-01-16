using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Camera))]

internal class CameraScrpt : MonoBehaviour
{
    [SerializeField] private bool uniform = true;
    [SerializeField] private bool autoSetUniform = false;
    private float pixSizeH;
    private float pixSizeW;

    public void Awake()
    {
        //Camera.main.orthographicSize = 1480;
    }

    private void Update()
    {
        pixSizeH = Camera.main.pixelHeight;
        pixSizeW = Camera.main.pixelWidth;
        Debug.Log(pixSizeW + " Высота " + pixSizeH + " Ширина Экрана ");
        Camera.main.orthographicSize = pixSizeH/pixSizeW * 1000;
        Debug.Log(Camera.main.orthographicSize + " Высота камеры"); 
        
        //Debug.Log(Camera.main.orthographicSize.ToString());
        //Debug.Log(pixSize.ToString());
        //Camera.main.orthographicSize = pixSize;
        //Debug.Log(Camera.main.orthographicSize.ToString());

    }
}
