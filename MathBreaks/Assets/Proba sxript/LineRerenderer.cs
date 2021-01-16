using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRerenderer : MonoBehaviour
{
    private LineRenderer lineRender;



    private void Start()
    {
        lineRender = GetComponent<LineRenderer>();
    }

    public void ShowTraectory(Vector3 startPos, Vector3 speed)
    {

        Vector3[] points = new Vector3[150];
        lineRender.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            float timeA = i; 
            points[i] = startPos + speed*12 * timeA;
            if (points[i].x > 700 || points[i].x < -700)
            {
                lineRender.positionCount = i;
                break;
            }
            if ((Mathf.Abs(points[0].y) + points[i].y) > 1800)
            {
                lineRender.positionCount = i;
                break;
            }
            if (points[0].y > points[i].y)
            {
                points[i].y = points[0].y;
                lineRender.positionCount = i;
                break;
            }
        }
        lineRender.SetPositions(points);

    }
}
