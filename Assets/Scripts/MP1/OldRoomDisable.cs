using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldRoomDisable : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;
    public GiantController m_Giant;

    //On Triggers Makes Specific Room Giant uncontrollable and Music stop playing
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                if (m_Giant.GetComponent<GiantOneAI>() != null)
                {
                    m_Giant.GetComponent<GiantOneAI>().enabled = false;
                }
                m_MusicBox.isactive = false;
                m_Giant.m_Controllable = false;
            }
        }
    }
}
