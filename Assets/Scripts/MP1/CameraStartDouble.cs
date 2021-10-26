using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartDouble : MonoBehaviour
{
    public float m_Timer = 0.0f;
    public float m_EndTimer = 0.0f;
    public GameObject m_NextCamera;
    private void LateUpdate()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer > m_EndTimer)
        {
            m_NextCamera.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
