using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public Death[] m_DeathObjects;
    public bool m_DeathObjectActive = true;

    public float m_Timer = 0.0f;

    private void Update()
    {
        if (!m_DeathObjectActive)
        {

            for (int i = 0; i < m_DeathObjects.Length; i++)
            {
                m_DeathObjects[i].gameObject.SetActive(false);
            }


        }

        for (int i = 0; i < m_DeathObjects.Length; i++)
        {
            if (m_DeathObjects[i].m_TouchedWater)
            {
                m_DeathObjectActive = false;
            }
        }
    }
}
