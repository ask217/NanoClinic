using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobyUI : MonoBehaviour
{

    public GameObject dialog;

    void Start()
    {
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dialog()
    {
        dialog.SetActive(true);
    }

    public void DialogF()
    {
        dialog.SetActive(false);
    }

}
