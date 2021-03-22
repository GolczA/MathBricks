using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroScene : MonoBehaviour
{
    [SerializeField] GameObject FirstBlock;
    [SerializeField] GameObject SecondBlock;
    [SerializeField] GameObject ThirdBlock;


    // круги вокруг кнопок англиский и русский язык
    [SerializeField] GameObject englishSpriteCircle;
    [SerializeField] GameObject russianhSpriteCircle;

    // это картинки в первом блоке правил 
    [SerializeField] GameObject englishChooseSecondBlock;
    [SerializeField] GameObject russianChooseSecondBlock;
    // это картинки во втором блоке правил 
    [SerializeField] GameObject englishChooseThirdBlock;
    [SerializeField] GameObject russianChooseThirdBlock;

    bool first = true;
    bool second = true;
    bool third = true;
    int count; 

    public void Awake()
    {
        count = 1;
        FirstBlock.SetActive(true);
        SecondBlock.SetActive(false);
        ThirdBlock.SetActive(false);
        englishSpriteCircle.SetActive(false);
        russianhSpriteCircle.SetActive(false);
        // второй блок
        englishChooseThirdBlock.SetActive(false);
        russianChooseThirdBlock.SetActive(false);

        second = false;
        third = false;
    }

    public void Start()
    {
        for (int i = 0; i < MainData.levelTrue.Length; i++)
        {
            if (MainData.levelTrue[i] == true)
            {
                count += 1;
            }
        }
        if (MainData.isFirstGame == true)
        {
            SceneManager.LoadScene(count);
        }
    }


    private void Update()
    {
        if (second == true)
        {
            if (MainData.isEnglish == true)
            {
                englishChooseSecondBlock.SetActive(true);
                russianChooseSecondBlock.SetActive(false);
            }
            if (MainData.isEnglish == false)
            {
                russianChooseSecondBlock.SetActive(true);
                englishChooseSecondBlock.SetActive(false);
            }
        }
        if (third == true)
        {
            if (MainData.isEnglish == true)
            {
                englishChooseThirdBlock.SetActive(true);
                russianChooseThirdBlock.SetActive(false);
            }
            if (MainData.isEnglish == false)
            {
                russianChooseThirdBlock.SetActive(true);
                englishChooseThirdBlock.SetActive(false);
            }
        }
    }

    #region FirstBlock
    public void EnglishBttnPress()
    {
        MainData.isEnglish = true;
        englishSpriteCircle.SetActive(true);
        russianhSpriteCircle.SetActive(false);
        MainData.isFirstGame = true;
    }

    public void RussBttnPress()
    {
        MainData.isEnglish = false;
        englishSpriteCircle.SetActive(false);
        russianhSpriteCircle.SetActive(true);
        MainData.isFirstGame = true; 
    }

    public void FirstForwardBttn()
    {
        FirstBlock.SetActive(false);
        ThirdBlock.SetActive(false);
        SecondBlock.SetActive(true);
        second = true;
    }

    #endregion

    #region SecondBlock
    public void ForwardSecondBlock()
    {
        FirstBlock.SetActive(false);
        ThirdBlock.SetActive(true);
        SecondBlock.SetActive(false);
        second = false;
        third = true;
    }
    public void BackSecondBlock()
    {
        FirstBlock.SetActive(true);
        ThirdBlock.SetActive(false);
        SecondBlock.SetActive(false);
        second = false;
        third = true;
    }

    #endregion

    #region ThirddBlock
    public void ForwardThirdBlock()
    {
        SceneManager.LoadScene(1);
    }
    public void BackThirdBlock()
    {
        FirstBlock.SetActive(false);
        ThirdBlock.SetActive(false);
        SecondBlock.SetActive(true);
        second = true;
        third = false;
    }


    #endregion


}
