using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbTrigger : MonoBehaviour
{
    public bool m_BoyTriggered = false;
    public bool m_ZHorizontal = false;
    public bool m_XReverse = false;
    Boy m_cacheBoy;

    public HighLightSwap shaderSwap;
    private void Start()
    {
        shaderSwap.swapToStandard();
    }
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>())
            {
                m_BoyTriggered = true;
                shaderSwap.swapToHighLight();
                m_cacheBoy = _other.GetComponent<Boy>();
            }
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>())
            {
                shaderSwap.swapToStandard();
                m_BoyTriggered = false;
                m_cacheBoy.m_IsClimbing = false;
                m_cacheBoy.m_CanClimb = false;
            }
        }
    }

    private void Update()
    {
        if (m_BoyTriggered)
        {
            m_cacheBoy.m_CanClimb = true;
            m_cacheBoy.m_ZHorizontal = m_ZHorizontal;
            m_cacheBoy.m_XReverse = m_XReverse;
        }
    }
}
