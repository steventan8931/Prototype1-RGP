using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldRoomDisable : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;
    public GiantController m_Giant;
    public butcherScr butcher;
    public int m_RoomsCleared = 0;

    //On Triggers Makes Specific Room Giant uncontrollable and Music stop playing
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                _other.GetComponent<Boy>().m_RoomsCleared = m_RoomsCleared;
                if (m_Giant.GetComponent<GiantOneAI>() != null)
                {
                    m_Giant.GetComponent<GiantOneAI>().enabled = false;
                }
                m_MusicBox.isactive = false;
                m_Giant.m_Controllable = false;
                butcher.isIdling = false;
                butcher.isSleep = false;
                print("butcher woken");
            }
        }
    }
}
