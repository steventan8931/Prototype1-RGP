using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Material m_Day;
    public Material m_Night;

    private Material m_CurrentMat;
    public float m_LerpTime = 0.0f;
    public float m_Lerp = 0.0f;
    public bool m_IsDay = false;

    private void Awake()
    {
        //RenderSettings.skybox = m_Night;
        m_CurrentMat = m_Day;
    }
    private void Update()
    {
        if (m_LerpTime >= 1.0f)
        {
            m_IsDay = true;
        }
        else if (m_LerpTime <= 0.0f)
        {
            m_IsDay = false;
        }

        if (m_IsDay)
        {
        }
        else
        {



        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            m_LerpTime = 1.0f;

        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            m_LerpTime = 0.0f;

        }

    }
}
