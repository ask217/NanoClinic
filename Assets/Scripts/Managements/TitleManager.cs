using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Image background;

    [SerializeField]
    Sprite title1;

    [SerializeField]
    Sprite title2;

    [SerializeField]
    Sprite title3;

    [SerializeField]
    Sprite title4;


    [SerializeField]
    GameObject window;

    bool isExit;

    void Start()
    {
        isExit = false;
        window.SetActive(false);

        int titleIndex = Random.Range(1, 50);
        Debug.Log(titleIndex);

        if (titleIndex <= 15)
        {
            background.sprite = title1;
        }
        else if (titleIndex <= 30)
        {
            background.sprite = title2;
        }
        else if (titleIndex <= 45)
        {
            background.sprite = title3;
        }
        else if (titleIndex <= 50)
        {
            background.sprite = title4;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isExit = !isExit;
            WindowAct();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && isExit)
        {
            isExit = false;
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Title");
        }
        else if (Input.anyKeyDown)
        {
            isExit = false;
            SceneManager.LoadScene("Main");
        }
    }

    public void WindowAct()
    {
        window.SetActive(!window.activeSelf);
    }
}
