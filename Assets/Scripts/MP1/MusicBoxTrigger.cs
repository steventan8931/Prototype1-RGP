using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxTrigger : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;
    public GameObject m_Camera;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                if (_other.GetComponent<Boy>().m_MusicPieceCollected)
                {
                    m_MusicBox.startMusic();
                    _other.GetComponent<Boy>().m_MusicPieceCollected = false;
                    m_Camera.SetActive(true);
                }

            }
        }
    }
}
