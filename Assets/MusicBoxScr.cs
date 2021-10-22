
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxScr : MonoBehaviour
{
    public bool isactive = false;
    public GameObject m_MusicComplete;
    public GameObject m_MusicMissing;
    public GiantController m_Giant;
    public bool m_BabyMusic = false;

    public AudioSource m_SoothingMusic;

    private void Start()
    {
        m_SoothingMusic = GameObject.Find("MusicBoxSFX").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isactive)
        {
            m_Giant.m_Controllable = true;
            if (!m_BabyMusic)
            {
                m_MusicComplete.SetActive(true);
                m_MusicMissing.SetActive(false);
            }

        }
        else
        {
            m_Giant.m_Controllable = false;
            m_SoothingMusic.Stop();
            if (!m_BabyMusic)
            {
                m_MusicComplete.SetActive(false);
                m_MusicMissing.SetActive(true);
            }
        }
    }

    public void startMusic()
    {
        isactive = true;
        m_Giant.m_IsControl = true;
        m_SoothingMusic.Play();
        //play music 
    }
}
