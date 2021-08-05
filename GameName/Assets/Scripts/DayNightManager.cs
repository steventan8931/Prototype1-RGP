using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public AudioSource m_Audio;
    public Light m_DirectionalLight;
    public DayNightData m_Data;
    public float m_TimeOfDay = 0.0f;

    public float m_TimeSpeed = 0.1f;

    public Giant m_Giant;
    public Vector2 m_NightExtentsEarly = new Vector2(0.0f, 8.0f);
    public Vector2 m_NightExtentsLate = new Vector2(18.0f, 24.0f);

    public GameObject m_ClockUI;

    private void Update()
    {
        if (m_TimeOfDay > m_NightExtentsEarly.x && m_TimeOfDay < m_NightExtentsEarly.y)
        {
            m_Giant.m_Controllable = true;
        }
        else if (m_TimeOfDay > m_NightExtentsLate.x && m_TimeOfDay < m_NightExtentsLate.y)
        {
            m_Giant.m_Controllable = true;
        }
        else
        {
            m_Giant.m_Controllable = false;
            m_Audio.Play();
        }

        m_ClockUI.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (-m_TimeOfDay * 15) -90);
        m_TimeOfDay += Time.deltaTime * m_TimeSpeed;
        m_TimeOfDay %= 24;
        UpdateLighting(m_TimeOfDay / 24);
    }
    private void UpdateLighting(float m_TimePercent)
    {
        RenderSettings.ambientLight = m_Data.m_AmbientColor.Evaluate(m_TimePercent);
        RenderSettings.fogColor = m_Data.m_FogColor.Evaluate(m_TimePercent);

        m_DirectionalLight.color = m_Data.m_DirectionalColor.Evaluate(m_TimePercent);
        m_DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((m_TimePercent * 360) - 90f, -170f, 0));

    }
}