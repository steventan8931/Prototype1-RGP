using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPromptControl : MonoBehaviour
{
    public bool m_IsGiantItem = true;

    public Canvas m_PromptCanvas;
    public GameObject m_InRangeUI;
    public GameObject m_InteractUI;

    public bool m_InRange = false;
    public bool m_CanInteract = false;

    GiantController m_Giant;
    Boy m_Boy;

    private void Start()
    {
        m_Giant = FindObjectOfType<GiantController>();
        m_Boy = FindObjectOfType<Boy>();

        m_InRangeUI = m_PromptCanvas.transform.GetChild(0).gameObject;
        m_InteractUI = m_PromptCanvas.transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (m_IsGiantItem)
        {
            if (m_Giant.m_IsControl)
            {
                if ((Vector3.Distance(transform.GetChild(0).position, m_Giant.transform.position) < 15) && m_Giant.m_Hands.childCount <= 0)
                {
                    m_InRange = true;
                }
                else
                {
                    m_InRange = false;
                }
            }

        }


        if (m_InRange)
        {
            if (m_CanInteract)
            {
                m_InteractUI.SetActive(true);
                m_InRangeUI.SetActive(false);
            }
            else
            {
                m_InRangeUI.SetActive(true);
                m_InteractUI.SetActive(false);
            }

        }
        else
        {
            m_InteractUI.SetActive(false);
            m_InRangeUI.SetActive(false);
        }
    }
}
