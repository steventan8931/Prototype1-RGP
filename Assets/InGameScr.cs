using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScr : MonoBehaviour
{
    public GameObject boy, giant;
    public GameObject boyIcon, giantIcon;
    public GameObject GameManager;//get the game manager object
    public GameObject WinUI;
    public GameObject BurnUI;
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

    public void checkBurn()
    {
        if (boyscr.m_Killed)
        {
            BurnUI.SetActive(true);
        }
        else
        {
            BurnUI.SetActive(false);
        }
    }

    public void checkChara()
    {
        if(boy.GetComponent<CharacterSwapper>().m_IsGiant)
        {
            boyIcon.GetComponent<CanvasGroup>().alpha = 0.4F;
            giantIcon.GetComponent<CanvasGroup>().alpha = 1F;
        }
        else
        {
            boyIcon.GetComponent<CanvasGroup>().alpha = 1F;
            giantIcon.GetComponent<CanvasGroup>().alpha = 0.4F;
        }
    }

    public void Update()
    {
        checkChara();
        checkDetect();
        checkWin();
        checkBurn();

    }
}
