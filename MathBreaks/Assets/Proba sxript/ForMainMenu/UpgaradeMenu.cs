using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgaradeMenu : MonoBehaviour
{
    public GameObject[] BttnInScrollMenu;
    int count; 

    private void Start()
    {
        
        for (int i = 0; i < MainData.levelTrue.Length; i++)
        {
            if (MainData.levelTrue[i] == true)
            {
                count += 1;
            }
        }
        for (int i = 0; i < BttnInScrollMenu.Length; i++)
        {
            if (i <= count)
            {
                BttnInScrollMenu[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                BttnInScrollMenu[i].GetComponent<Button>().interactable = false;
            }
        }
        Debug.Log(count.ToString());
    }
    public void BttPress0()
    {
        SceneManager.LoadScene(0);
    }
    public void BttPress1()
    {
        SceneManager.LoadScene(1);
    }
    public void BttPress2()
    {
        SceneManager.LoadScene(2);
    }
    /*public void BttPress3()
    {
        SceneManager.LoadScene(3);
    }
    public void BttPress4()
    {
        SceneManager.LoadScene(4);
    }
    public void BttPress5()
    {
        SceneManager.LoadScene(5);
    }*/
}
