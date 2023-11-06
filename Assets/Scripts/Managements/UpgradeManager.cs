using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject UpgradeWindow;

    private bool IsWindowOpen;

    void Start()
    {
        UpgradeWindow.SetActive(false);
        IsWindowOpen = UpgradeWindow.activeSelf;
    }

    void Update()
    {

    }
}
