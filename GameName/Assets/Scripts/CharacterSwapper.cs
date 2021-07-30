using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwapper : MonoBehaviour
{
    public bool m_IsGiant;

    public GameObject m_Boy;
    public GameObject m_Giant;

    private void Update()
    {
        if (m_Giant.GetComponent<Giant>().m_Controllable)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                m_IsGiant = !m_IsGiant;
            }
        }
        else
        {
            m_IsGiant = false;
        }


        if(m_IsGiant)
        {
            m_Giant.GetComponent<CharacterMotor>().m_IsControl = true;
            m_Giant.GetComponent<CharacterMotor>().m_Look.m_AttachedCamera.enabled = true;
            m_Boy.GetComponent<CharacterMotor>().m_IsControl = false;
            m_Boy.GetComponent<CharacterMotor>().m_Look.m_AttachedCamera.enabled = false;
        }
        else
        {
            m_Giant.GetComponent<CharacterMotor>().m_IsControl = false;
            m_Giant.GetComponent<CharacterMotor>().m_Look.m_AttachedCamera.enabled = false;
            m_Boy.GetComponent<CharacterMotor>().m_IsControl = true;
            m_Boy.GetComponent<CharacterMotor>().m_Look.m_AttachedCamera.enabled = true;
        }
    }
}
