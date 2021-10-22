using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPromptControl : MonoBehaviour
{
    public bool m_IsGiantItem = true;

    public bool m_InRange = false;
    public bool m_CanInteract = false;

    public GiantController m_Giant;
    Boy m_Boy;
    weeBabyScr m_Baby;

    private void Start()
    {
        m_Boy = FindObjectOfType<Boy>();
        m_Baby = FindObjectOfType<weeBabyScr>();
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


    }
}
