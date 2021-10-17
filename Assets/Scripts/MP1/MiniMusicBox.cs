using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMusicBox : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                m_MusicBox.isactive = true;
            }
                       
        }
    }
}
