using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public AudioSource[] m_AudioSources;
    public GameObject baby;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            m_AudioSources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < m_AudioSources.Length; i++)
            {
                m_AudioSources[i].Stop();
            }
            _other.gameObject.GetComponent<Boy>().m_Look.m_CursorLocked = false;
            _other.gameObject.GetComponent<Boy>().m_Look.LockCursor();
            _other.gameObject.GetComponent<Boy>().enabled = false;
            baby.GetComponent<CharacterSwapper>().enabled = false;
            _other.gameObject.GetComponent<Boy>().m_GameWon = true;


        }
    }




}
