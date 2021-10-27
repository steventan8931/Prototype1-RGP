using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCameraLoad : MonoBehaviour
{
    public GameObject m_FirstCam;

    public float m_Timer = 0.0f;
    public float m_EndTimer = 1.0f;

    private void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer > m_EndTimer)
        {
            m_FirstCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
