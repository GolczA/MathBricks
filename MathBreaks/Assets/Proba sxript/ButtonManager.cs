using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public BoxCollider2D PlayField;
    public GameObject LoseAdvMenu;
    public GameObject WinAdvMenu;
    public GameObject mainBull;
    public Transform startPoint;
    Transform startPosition;

    public GameObject CancelfromGame;// кнопка отмены в игровом поле
    public GameObject UpgrBttfromGame;// кнопка перехода в апгрейд меню в игровом поле
    public GameObject mainBullToStartposition; // кнопка которая возращает мяч в начальную позицию 
    public GameObject restrtButt; // рестартит уровень 


    // pause menu
    public GameObject PauseMenu;
    bool isWork;
    Vector3 pauseBttnStartPosition;

    // проверка индекса сцена
    int indexScene;

    private void Start()
    {
        isWork = false; // включена ли пауза
        MainData.isEnglish = true; // язык англиский или нет
        indexScene = SceneManager.GetActiveScene().buildIndex; // определяем индекс текущей сцены
        startPosition = startPoint;
    }

    #region Меню внутри игрового поля C#
    // внутри игрового поля
    public void CancelPlayMenu()// вернуться в главное меню 
    {
        MainData.isPause = true; // нужно чтобы игра понимала откуда мы пришли в это положение
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        if (isWork == false)
        {
            CancelfromGame.SetActive(false);
            UpgrBttfromGame.SetActive(false);
            mainBullToStartposition.SetActive(false);
            restrtButt.SetActive(false);
            pauseBttnStartPosition = PauseMenu.GetComponent<Transform>().position;
            Time.timeScale = 0;
            PauseMenu.transform.position = new Vector3(0, 0, 0);
            PauseMenu.transform.localScale = new Vector3(3, 3, 0);
            PlayField.enabled = false;
            isWork = true;
        }
        else
        {
            CancelfromGame.SetActive(true);
            UpgrBttfromGame.SetActive(true);
            mainBullToStartposition.SetActive(true);
            restrtButt.SetActive(true);
            Time.timeScale = 1;
            PauseMenu.transform.position = pauseBttnStartPosition;
            PauseMenu.transform.localScale = new Vector3(1, 1, 0);
            PlayField.enabled = true;
            isWork = false;
        }
    }

    public void ReStartLevel()
    {
        if (MainData.howMatchrestart % 5 == 0)
        {
            Debug.Log("Смотрим рекламу");
            SceneManager.LoadScene(indexScene);
            MainData.howMatchrestart += 1; 
        }
        else
        {
            SceneManager.LoadScene(indexScene);
            MainData.howMatchrestart += 1;
            Debug.Log(MainData.howMatchrestart);
        }
    } 
    public void UgrBttnInGame()
    {
        SceneManager.LoadScene("MainMenu");
        MainData.isPause = true; 
    }

    public void BullToStartPoint()
    {
        mainBull.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        mainBull.transform.position = startPosition.position;
    }

    #endregion

    #region Меню Рекламы WIN и LOSE
    // кнопки LoseMenu 
    public void LoseCancelAdvs()
    {
        MainData.howMatchLose += 1; 
        SceneManager.LoadScene("MainMenu");
    }
    public void LoseYesAdvs()
    {
        MainData.howMatchLose += 1;
        MouseMove.attemption += 1;
        LoseAdvMenu.SetActive(false);
        PlayField.enabled = true;
    }
    // кнопки WinMenu
    public void WinCancelAdvs()
    {
        MainData.howMatchWin += 1; 
        SceneManager.LoadScene("MainMenu");
    }
    public void WinYesAdvs()
    {
        MainData.howMatchWin += 1; 
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
