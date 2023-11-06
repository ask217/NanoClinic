using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordingControll : MonoBehaviour
{
    SpriteRenderer sr;

    GameObject wording;

    void Start()
    {
        wording = gameObject;
        sr = wording.GetComponent<SpriteRenderer>();
    }

    public void OnMouseEnter()
    {
        sr.material.color = new Color(150 / 255f, 150 / 255f, 150 / 255f);
    }

    public void OnMouseExit()
    {
        sr.material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }
}
