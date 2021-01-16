using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class SaveProba : MonoBehaviour
{
    public static int count;
    public int counter;
    string str;

    public void Start()
    {
        if (PlayerPrefs.HasKey("MainData1"))
        {
            str = PlayerPrefs.GetString("MainData1");
            JsonUtility.FromJsonOverwrite(str, this);
        }
        else
        {
            counter = 45;
        }
        Debug.Log(counter);
        count = counter;

    }
    private void Update()
    {
        Debug.Log(count.ToString() + "  это статик" + counter.ToString() + " Это общий ");
    }

    public void SaveObject()
    {
        str = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("MainData1", str);
    }

    public void PLus()
    {
        counter += 1;
    }

    public void Delll()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnApplicationQuit()
    {
        str = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("MainData1", str);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
        




}
