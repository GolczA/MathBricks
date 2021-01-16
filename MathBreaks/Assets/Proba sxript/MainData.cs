using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


[Serializable]
public class MainData : MonoBehaviour
{
    public static int[] pointToWinLevels; // количество очков для прохождения уровня    Ненужно сохранять
    public static float[] playerRecordToLevels; // очки которые набал игрок на каждом уровне НУЖНО
    public static bool[] levelTrue; // открываем возможность клика по следующему уровню НУЖНО
    public static float bullMass; // масса мяча 
    public static float bullSpeed; // скорость мяча
    public static int playerUpgradePoints; // очки игрока которые он будет тратить на обгрейд 
    public static int attemption; // количество попыток 

    public static bool isEnglish; // язык
    public static bool isSoundOn; // музыка

    public static int howMatchWin; //реклама будет показываться только каждый 3 выигрыш
    public static int howMatchLose; //реклама будет показываться только каждый 3 проигрыш
    public static int howMatchrestart; //реклама будет показываться только каждый 5 рестарт игры из игры)


    public static int indexScene; //этот индекс сцен будет пердаваться между сценами при победе, поражении
    public static bool isPause; // если тру знаичт мы перешли в мэйн меню из игры, победы и порожения не было
    public static bool isWin; // если тру знаичт мы перешли в мэйн меню из игры после победы
    public static bool isLose; // если тру знаичт мы перешли в мэйн меню из игры после поражения

    #region не статические данные
    public int[] pointToWinLevelsNoStat; // количество очков для прохождения уровня
    public float[] playerRecordToLevelsNoStat; // очки которые набал игрок на каждом уровне
    public bool[] levelTrueNoStat; // открываем возможность клика по следующему уровню
    public float bullMassNoStat; // масса мяча
    public float bullSpeedNoStat; // скорость мяча
    public int playerUpgradePointsNoStat; // очки игрока которые он будет тратить на обгрейд 
    public int attemptionNoStat; // количество попыток 
    
    public bool isEnglishNoStat; // язык
    public bool isSoundOnNoStat; // музыка

    public int howMatchWinNoStat; //реклама будет показываться только каждый 3 выигрыш
    public int howMatchLoseNoStat; //реклама будет показываться только каждый 3 проигрыш
    public int howMatchrestartNoStat; //реклама будет показываться только каждый 5 рестарт игры из игры)


    public int indexSceneNoStat; //этот индекс сцен будет пердаваться между сценами при победе, поражении
    public bool isPauseNoStat; // если тру знаичт мы перешли в мэйн меню из игры, победы и порожения не было
    public bool isWinNoStat; // если тру знаичт мы перешли в мэйн меню из игры после победы
    public bool isLoseNoStat; // если тру знаичт мы перешли в мэйн меню из игры после поражения
    #endregion
    [Multiline(50)]
    public string stringForSave;

    public int fackincount;





    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MainData");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            Debug.Log($"этот объект уничтожен --- {fackincount}, количество обьектов {objs.Length}");
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            if (PlayerPrefs.HasKey("MainMenu"))
            {
                stringForSave = PlayerPrefs.GetString("MainMenu");
                JsonUtility.FromJsonOverwrite(stringForSave, this);
                ChangeToLaod();
            }
            else
            {
                Debug.Log("Работает не загрузка");
                pointToWinLevels = new int[3] { 2, 2, 2 };
                playerRecordToLevels = new float[3] { 0, 0, 0 };
                levelTrue = new bool[3] { false, false, false };

                howMatchWin = 3;
                howMatchLose = 3;
                howMatchrestart = 2;
                playerUpgradePoints = 25;

                indexScene = SceneManager.GetActiveScene().buildIndex;
                isPause = false;
                isWin = false;
                isLose = false;

                attemption = 9;
                bullMass = 2.1f;
                bullSpeed = 2000;
            }
        }
    }

    public void Update()
    {
        Debug.Log($"{howMatchWin} значения счетчика побед");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void DelSaveData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveGame()
    {
        ChangeToSaveData();
        stringForSave = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString("MainMenu", stringForSave);
    }

    public void ChangeToSaveData()
    {
        pointToWinLevelsNoStat = pointToWinLevels;
        playerRecordToLevelsNoStat = playerRecordToLevels;
        levelTrueNoStat = levelTrue;
        bullMassNoStat = bullMass;
        bullSpeedNoStat = bullSpeed;
        playerUpgradePointsNoStat = playerUpgradePoints;
        attemptionNoStat = attemption;

        isEnglishNoStat = isEnglish;
        isSoundOnNoStat = isSoundOn;

        howMatchWinNoStat = howMatchWin;
        howMatchLoseNoStat = howMatchLose;
        howMatchrestartNoStat = howMatchrestart;

        indexSceneNoStat = indexScene;
        isPauseNoStat = isPause;
        isWinNoStat = isWin;
        isLoseNoStat = isLose;
    }
    public void ChangeToLaod()
    {
        pointToWinLevels = pointToWinLevelsNoStat;
        playerRecordToLevels = playerRecordToLevelsNoStat;
        levelTrue = levelTrueNoStat;
        bullMass = bullMassNoStat;
        bullSpeed = bullSpeedNoStat;
        playerUpgradePoints = playerUpgradePointsNoStat;
        attemption = attemptionNoStat;

        isEnglish = isEnglishNoStat;
        isSoundOn = isSoundOnNoStat;

        howMatchWin = howMatchWinNoStat;
        howMatchLose = howMatchLoseNoStat;
        howMatchrestart = howMatchrestartNoStat;

        indexScene = indexSceneNoStat;
        isPause = isPauseNoStat;
        isWin = isWinNoStat;
        isLose = isLoseNoStat;

    }


}
