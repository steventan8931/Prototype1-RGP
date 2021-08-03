using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScr : MonoBehaviour
{
    public GameObject boy, giant;
    public GameObject GameManager;//get the game manager object
    public GameObject WinUI;
    public Boy boyscr;
    public GameState winstate;
    public GameObject DetectedUi;

    public void checkDetect()
    {
        if(boyscr.m_Detected)
        {
            DetectedUi.SetActive(true);
        }else
        {
            DetectedUi.SetActive(false);
        }
    }

    public void checkWin()
    {
        if(winstate.m_GameWin)
        {
            WinUI.SetActive(true);

        }
    }

    public void Update()
    {
        checkDetect();
        checkWin();
    }
}
