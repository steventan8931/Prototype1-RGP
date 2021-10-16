
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxScr : MonoBehaviour
{
    public bool isactive = false;

    public GiantController m_Giant;

    private void Update()
    {
        if (isactive)
        {
            m_Giant.m_Controllable = true;
        }
        else
        {
            m_Giant.m_Controllable = false;
        }
    }

    public void startMusic()
    {
        isactive = true;
        //play music 
    }
}
