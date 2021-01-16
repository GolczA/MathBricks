using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBttn : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject meinMenu;
    [SerializeField] GameObject scrollMenu;
    [SerializeField] GameObject playBttn;

    // для Sound конпки 
    [SerializeField] GameObject soundBttn;
    public Sprite soundOffSprite;
    public Sprite soundOnSprite;

    // для LangBttn кнопки
    [SerializeField] GameObject langBttn;
    public Sprite russian;
    public Sprite england;

    [SerializeField] Text score; // будет выводить количество очков которые набрал игрок

    private void Start()
    {
        score.text = (MainData.playerUpgradePoints).ToString();
        if (MainData.isPause == true) upgradeMenu.SetActive(true);
    }


    #region Главное меню 

    public void PlayBttn()
    {
        if (MainData.isWin == true)
        {
            SceneManager.LoadScene(MainData.indexScene + 1);
            MainData.isWin = false; 
        }
        if (MainData.isLose == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isLose = false; 
        }
        if (MainData.isPause == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isPause = false; 
        }
    }

    public void ReStart()
    {
        if (MainData.isWin == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isWin = false;
        }
        if (MainData.isLose == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isLose = false;
        }
        if (MainData.isPause == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isPause = false;
        }
    }
    public void CancelMeinMenu()
    {
        Application.Quit();
        Debug.Log("Вышли из игры");
    }

    public void ChooseLvl()
    {
        scrollMenu.SetActive(true);
    }

    public void SoundBtt()
    {
        Debug.Log(MainData.isSoundOn);
        if (MainData.isSoundOn == true)
        {
            soundBttn.GetComponent<Image>().sprite = soundOffSprite;
            MainData.isSoundOn = !MainData.isSoundOn;
            Debug.Log(MainData.isSoundOn);
        }
        else
        {
            soundBttn.GetComponent<Image>().sprite = soundOnSprite;
            MainData.isSoundOn = !MainData.isSoundOn;
            Debug.Log("Сработал");
        }
    }
    public void LangBttn()
    {
        if (MainData.isEnglish == true)
        {
            langBttn.GetComponent<Image>().sprite = russian;
            MainData.isEnglish = false;
        }
        else
        {
            langBttn.GetComponent<Image>().sprite = england;
            MainData.isEnglish = true;
        }
    }
    public void ReviewBttn()
    {
        Application.OpenURL("https://www.google.ru/");
    }

    public void UpgradeBttn()
    {
        meinMenu.SetActive(false);
        upgradeMenu.SetActive(true); 
    }

    #endregion

    #region Апгрейд меню
    public void ToBack()
    {
        if (MainData.isPause == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isPause = false;
        }
        else
        {
            meinMenu.SetActive(true);
            upgradeMenu.SetActive(false);
        }
    }

    #endregion
}
