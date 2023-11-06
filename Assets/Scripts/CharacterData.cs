using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public Sprite characterImage;

    public string characterName;
    public string characterType;

    public int buttonCount; // 버튼의 개수를 체크 합니다

    // 각 버튼에 들어가는 문장을 입력합니다 만일 없다면 null을 입력하세요
    public string buttonText1;
    public string buttonText2;
    public string buttonText3;

    public void Button1()
    {
        //TODO:대사 바꾸기
    }

    public void button2()
    {
        GameObject upgradeWindow = GameObject.Find("Upgrade");
        upgradeWindow.SetActive(true);
    }

    public void Button3()
    {
        GameObject dialogWindow = GameObject.Find("Dialog");
        dialogWindow.SetActive(false);
    }

    public string DefaultLine; // 따로 주어진 대사가 없을 경우 출력하는 대사를 입력합니다


}
