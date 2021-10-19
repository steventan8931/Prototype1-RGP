using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutingCone : MonoBehaviour
{
    public AudioSource m_Audio;
    Boy m_Boy;
    bool m_IsDetected = false;
    public float m_DetectedTimer = 0.0f;
    private void Start()
    {
        m_Boy = FindObjectOfType<Boy>();
    }
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Detected = true;
            m_IsDetected = true;
            m_Audio.Play();
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            m_Audio.Stop();
        }
    }

    private void Update()
    {
        if (m_IsDetected)
        {
            m_DetectedTimer += Time.deltaTime;
        }
        if(!m_Boy.m_Detected && m_DetectedTimer > 0.5f)
        {
            m_Audio.Stop();
            m_IsDetected = false;
            m_DetectedTimer = 0.0f;
        }

    }
}