using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwapper : MonoBehaviour
{
    public bool m_IsGiant = false;

    public GameObject m_Boy;
    public GameObject m_Giant;

    public GameObject m_SwapperEffectPrefab;

    public AudioSource m_SwapSound;

    private void Start()
    {
        m_Giant.GetComponent<GiantController>().m_IsControl = false;
        m_Giant.GetComponent<GiantController>().m_Look.m_AttachedCamera.enabled = false;
        m_Boy.GetComponent<Boy>().m_IsControl = true;
        m_Boy.GetComponent<Boy>().m_Look.m_AttachedCamera.enabled = true;
    }
    private void Update()
    {
        if (m_Giant.GetComponent<GiantController>().m_Controllable)
        {
            m_Giant.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.T))
            {
                m_SwapSound.Play();
                m_IsGiant = !m_IsGiant;
                if (m_IsGiant)
                {
                    Instantiate(m_SwapperEffectPrefab, m_Boy.transform.position, Quaternion.identity);
                    Instantiate(m_SwapperEffectPrefab, m_Boy.transform.position + new Vector3(0.0f, -2f, 0.0f), Quaternion.identity);
                    Instantiate(m_SwapperEffectPrefab, m_Boy.transform.position + new Vector3(0.0f, 2f, 0.0f), Quaternion.identity);
                }
                else
                {
                    Instantiate(m_SwapperEffectPrefab, transform.position, Quaternion.identity);
                    Instantiate(m_SwapperEffectPrefab, transform.position + new Vector3(0.0f, -2f, 0.0f), Quaternion.identity);
                    Instantiate(m_SwapperEffectPrefab, transform.position + new Vector3(0.0f, 2f, 0.0f), Quaternion.identity);
                }

            }

            if (m_IsGiant)
            {
                m_Giant.GetComponent<GiantController>().m_IsControl = true;
                m_Giant.GetComponent<GiantController>().m_Look.m_AttachedCamera.enabled = true;
                m_Boy.GetComponent<Boy>().m_IsControl = false;
                m_Boy.GetComponent<Boy>().m_Look.m_AttachedCamera.enabled = false;
            }
            else
            {
                m_Giant.GetComponent<GiantController>().m_IsControl = false;
                m_Giant.GetComponent<GiantController>().m_Look.m_AttachedCamera.enabled = false;
                m_Boy.GetComponent<Boy>().m_IsControl = true;
                m_Boy.GetComponent<Boy>().m_Look.m_AttachedCamera.enabled = true;
            }
        }
        else
        {
            m_IsGiant = false;
            m_Giant.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        }

    }
}
