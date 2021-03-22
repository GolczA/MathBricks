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

    GameObject mainMenu;

    [SerializeField] AudioSource noMoneyMusic;
    [SerializeField] AudioSource upgradeMusic;

    // для Sound конпки 
    [SerializeField] GameObject soundBttn;
    public Sprite soundOffSprite;
    public Sprite soundOnSprite;

    // для LangBttn кнопки
    [SerializeField] GameObject langBttn;
    public Sprite russian;
    public Sprite england;

    [SerializeField] Text score; // будет выводить количество очков которые набрал игрок

    //Для апгрейда
    int UpgradeToOne;
    int UpgradeToOneTenth;
    public Text bullMass;
    public Text bullSpeed;

    private void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainData");
        UpgradeToOne = 1000;
        UpgradeToOneTenth = 100;
        bullMass.text = (MainData.bullMass).ToString();
        bullSpeed.text = (MainData.bullSpeed).ToString();
        score.text = (MainData.playerUpgradePoints).ToString();
        if (MainData.isUpgrade == true) upgradeMenu.SetActive(true);
    }

    private void Update()
    {
        bullMass.text = (MainData.bullMass).ToString();
        bullSpeed.text = (MainData.bullSpeed).ToString();
        score.text = (MainData.playerUpgradePoints).ToString();
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
            mainMenu.GetComponent<AudioSource>().Stop(); 
        }
        else
        {
            soundBttn.GetComponent<Image>().sprite = soundOnSprite;
            MainData.isSoundOn = !MainData.isSoundOn;
            mainMenu.GetComponent<AudioSource>().Play();
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
        if (MainData.isUpgrade == true)
        {
            SceneManager.LoadScene(MainData.indexScene);
            MainData.isUpgrade = false;
        }
        else
        {
            meinMenu.SetActive(true);
            upgradeMenu.SetActive(false);
        }
    }

    public void IncreaseMaasOnOneKilo()
    {
        if (MainData.playerUpgradePoints >= UpgradeToOne)
        {
            MainData.playerUpgradePoints -= UpgradeToOne;
            MainData.bullMass += 1;
            UpgradePlayMusic(); 
        }
        else
        {
            NoMoneyPlayMusic();
        }

    }

    public void IncreaseMaasOnOneTenhtKilo()
    {
        if (MainData.playerUpgradePoints >= UpgradeToOneTenth)
        {
            MainData.playerUpgradePoints -= UpgradeToOneTenth;
            MainData.bullMass += 0.1f;
            UpgradePlayMusic();
        }
        else
        {
            NoMoneyPlayMusic();
        }

    }

    public void IncreaseSpeedOnOneTenht()
    {
        if (MainData.playerUpgradePoints >= UpgradeToOneTenth)
        {
            MainData.playerUpgradePoints -= UpgradeToOneTenth;
            MainData.bullSpeed += 100f;
            UpgradePlayMusic();
        }
        else
        {
            NoMoneyPlayMusic();
        }

    }

    public void IncreaseSpeedOnOne()
    {
        if (MainData.playerUpgradePoints >= UpgradeToOne)
        {
            MainData.playerUpgradePoints -= UpgradeToOne;
            MainData.bullSpeed += 1000f;
            UpgradePlayMusic();

        }
        else
        {
            NoMoneyPlayMusic();
        }

    }

    #endregion

    void NoMoneyPlayMusic()
    {
        noMoneyMusic.Play();
    } // нет денег запуск музыки
    void UpgradePlayMusic()
    {
        upgradeMusic.Play();
    } // апгрейд удачный
}

