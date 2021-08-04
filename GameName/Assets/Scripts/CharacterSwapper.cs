using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwapper : MonoBehaviour
{
    public bool m_IsGiant;

    public GameObject m_Boy;
    public GameObject m_Giant;

    public GameObject m_SwapperEffectPrefab;

    public AudioSource m_SwapSound;

    private void Update()
    {
        if (m_Giant.GetComponent<Giant>().m_Controllable)
        {
            m_Giant.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.T))
            {
                m_SwapSound.Play();
                m_IsGiant = !m_IsGiant;
                Instantiate(m_SwapperEffectPrefab, transform.position, Quaternion.identity);
                Instantiate(m_SwapperEffectPrefab, transform.position + new Vector3(0.0f, -2f, 0.0f), Quaternion.identity);
                Instantiate(m_SwapperEffectPrefab, transform.position + new Vector3(0.0f, 2f,0.0f), Quaternion.identity);
            }
        }
        else
        {
            m_IsGiant = false;
            m_Giant.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
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
