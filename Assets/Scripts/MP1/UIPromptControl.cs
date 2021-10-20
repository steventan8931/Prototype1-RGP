﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPromptControl : MonoBehaviour
{
    public bool m_IsGiantItem = true;

    public Canvas m_PromptCanvas;
    GameObject m_InRangeUI;
    GameObject m_InteractUI;

    public bool m_InRange = false;
    public bool m_CanInteract = false;

    public GiantController m_Giant;
    Boy m_Boy;
    weeBabyScr m_Baby;

    private void Start()
    {
        m_Boy = FindObjectOfType<Boy>();
        m_Baby = FindObjectOfType<weeBabyScr>();

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
            else
            {
                m_InRange = false;
            }

        }
        else
        {
            if (m_Boy.m_IsControl && m_Baby.GetComponent<GiantController>().m_Controllable)
            {
                if ((Vector3.Distance(transform.GetChild(0).position, m_Boy.transform.position) < 15) && m_Boy.m_Hands.childCount <= 0)
                {
                    m_InRange = true;
                }
                else
                {
                    m_InRange = false;
                }
            }
            else
            {
                m_InRange = false;
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
