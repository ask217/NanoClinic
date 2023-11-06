using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public UIManager instance;
    public GameObject dialog;
    public Image characterImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lineText;
    public List<GameObject> dialogButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        characterImage = GetComponent<Image>();

        dialog.SetActive(false);
    }

    public void WindowActiveChange(GameObject window)
    {
        window.SetActive(!window.activeSelf);
    }

    public void DialogOpen(CharacterData data)
    {
        characterImage.sprite = data.characterImage;
        nameText.text = data.characterName;
        lineText.text = data.DefaultLine;

        switch (data.buttonCount)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    dialogButton[i].SetActive(false);
                }
                break;
            case 1:
                dialogButton[0].SetActive(true);
                break;
            case 2:
                dialogButton[0].SetActive(true);
                dialogButton[1].SetActive(true);
                break;
            case 3:
                dialogButton[0].SetActive(true);
                dialogButton[1].SetActive(true);
                dialogButton[2].SetActive(true);
                break;
        }

        dialog.SetActive(true);
    }

    public void Button1(CharacterData data)
    {
        data.Button1();
    }

    public void Button2(CharacterData data)
    {
        data.button2();
    }

    public void Button3(CharacterData data)
    {
        data.Button3();
    }
}
