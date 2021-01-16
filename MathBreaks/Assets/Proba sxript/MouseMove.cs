using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseMove : MonoBehaviour
{
    public Transform startPoint; // место положения круга в котором помещается мяч

    public LineRerenderer lineRerenderer; 

    [SerializeField] GameObject MainBull; // главный мяч
    [SerializeField] Text Attemption; // показывает оставшееся количество попыток
    [SerializeField] Text ScoreNow; // показывает текущий счет

    [SerializeField] LevelGO levelGo;
    [SerializeField] GameObject WinMenuAdds;
    [SerializeField] GameObject LoseMenuAdds;
    [SerializeField] Rigidbody2D[] rbBlocks;

    Vector3 startBallPos; // начальная позиция мяча, при касании мыши мяч появляется в этой точке 

    Rigidbody2D rb; // риджит боди мяча, нужно для движения
    Vector3 laserGoTo;

    public static int attemption; 
    int levelUpScore; // очки для прохождения уровня гет комп от MainData
    int indexScene; // это для внутренних дел связанных с индексом сцен (сохранение данных в масивы)


 
    private void Start()
    {
        MainData.indexScene = SceneManager.GetActiveScene().buildIndex;
        indexScene = SceneManager.GetActiveScene().buildIndex;
        rb = MainBull.GetComponent<Rigidbody2D>();
        startBallPos = startPoint.position;
        attemption = MainData.attemption;
        levelUpScore = MainData.pointToWinLevels[indexScene];
        ScoreNow.text = 0 + "|" + levelUpScore.ToString();
        Attemption.text = attemption.ToString();
    }

    private void Update()
    {
        if (attemption == 0)
        {
            if (AllObjectStay(rbBlocks) == true && MainBullStay(rb) == true) //проверка мяч и все объекты стоят
            {
                if (levelGo.scoreNow >= levelUpScore)
                {
                    Win();
                }

                if (levelGo.scoreNow < levelUpScore && MainData.howMatchLose%3 == 0)
                {
                    Lose();
                }
                if (levelGo.scoreNow < levelUpScore && MainData.howMatchLose % 3 != 0)
                {
                    MainData.howMatchLose += 1;
                    MainData.isLose = true;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
        
        if (AllObjectDestroy(rbBlocks) == true) // проверка что все объекты уничтожены
        {
            if (levelGo.scoreNow >= levelUpScore)
            {
                Win();
            }

            if (levelGo.scoreNow < levelUpScore && MainData.howMatchLose % 3 == 0)
            {
                Lose();
            }
            if (levelGo.scoreNow < levelUpScore && MainData.howMatchLose % 3 != 0)
            {
                MainData.howMatchLose += 1;
                MainData.isLose = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
        Attemption.text = attemption.ToString();

    }
    private void OnMouseDrag()
    {
        if (attemption > 0)
        {
            startBallPos = startPoint.position;
            MainBull.transform.position = startBallPos;
            MainBull.SetActive(true);
            Vector3 mousePos = Input.mousePosition; // координаты мыши, и их перевод в глобал 
            Vector3 mousePosWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            laserGoTo = new Vector3(mousePosWorldPosition.x, mousePosWorldPosition.y + Mathf.Abs(startBallPos.y), 0.0f).normalized;
            lineRerenderer.gameObject.SetActive(true);
            lineRerenderer.ShowTraectory(startBallPos, laserGoTo);
        }
    }

    private void OnMouseUp()
    {
        if(attemption > 0)
        {
            lineRerenderer.gameObject.SetActive(false);
            attemption -= 1;
            GameObjectMove(rb, laserGoTo.normalized * MainData.bullSpeed);
        }
    }

    void GameObjectMove(Rigidbody2D bulls, Vector2 speed)
    {
        bulls.velocity = speed;
    }
    public void Win()
    {
        if (MainData.howMatchWin % 3 == 0)
        {
            if (MainData.playerRecordToLevels[indexScene] < levelGo.scoreNow)
            {
                MainData.playerRecordToLevels[indexScene] = levelGo.scoreNow;
            }
            MainData.levelTrue[indexScene] = true;
            WinMenuAdds.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            MainData.isWin = true;
        }
        else
        {
            if (MainData.playerRecordToLevels[indexScene] < levelGo.scoreNow)
            {
                MainData.playerRecordToLevels[indexScene] = levelGo.scoreNow;
            }
            MainData.levelTrue[indexScene] = true;
            if (gameObject.GetComponent<BoxCollider2D>().enabled != false)//после выбора рекламы изменяется значениеи howMatchWin и отрабтыается еще одно условие и в результате этот параметр увеличивается на 2
            {
                MainData.howMatchWin += 1;
            }
            MainData.isWin = true;
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Бля я сработал");
        }

    }

    public void Lose()
    {
        if (MainData.howMatchLose % 3 == 0)
        {
            MainData.isLose = true; 
            LoseMenuAdds.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            MainData.isLose = true; 
            MainData.howMatchLose += 1;
            SceneManager.LoadScene("MainMenu");
        }
    }

    bool AllObjectDestroy(params Rigidbody2D[] blocks) 
    {
        int count = 0;
        for(int i = 0; i < blocks.Length; i ++)
        {
            if (blocks[i] == null)
            {
                count += 1;
            }
            
        }
        if (count == blocks.Length)
        {
            return true;
        }
        else return false;
    }
    bool AllObjectStay(params Rigidbody2D[] blocks)
    {
        int count = 0;
        Vector2 stay = new Vector2(0, 0);
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] == null || blocks[i].velocity == stay)
            {
                count += 1;
            }
        }
        if (count == blocks.Length) return true;
        else return false;
    }
    bool MainBullStay(Rigidbody2D mainBull)
    {
        Vector2 stay = new Vector2(0, 0);
        if (mainBull.velocity == stay)
        {
            return true;
        }
        else return false; 
    }
       

}
