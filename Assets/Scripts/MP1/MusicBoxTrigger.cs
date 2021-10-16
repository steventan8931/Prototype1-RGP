using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxTrigger : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                if (_other.GetComponent<Boy>().m_MusicPieceCollected)
                {
                    m_MusicBox.isactive = true;
                    _other.GetComponent<Boy>().m_MusicPieceCollected = false;
                }

            }
        }
    }
}
