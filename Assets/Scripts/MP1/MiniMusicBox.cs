using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMusicBox : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;
    public GameObject m_Camera;
    bool doOnce = false;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                if (!doOnce)
                {
                    m_Camera.SetActive(true);
                    doOnce = true;
                }

                m_MusicBox.isactive = true;
            }
                       
        }
    }
}
