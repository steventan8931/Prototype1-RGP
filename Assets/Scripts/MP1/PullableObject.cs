using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullableObject : MonoBehaviour
{
    public GameObject m_Model;

    public HighLightSwap shaderSwap;
    public bool m_PickedUp = false;
    public bool m_GiantInRange = false;
    GiantController cahceGiant;
    HighlightObject m_Highlight;

    private void Start()
    {
        m_Highlight = m_Model.GetComponent<HighlightObject>();
    }

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (_other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                m_GiantInRange = true;
                cahceGiant = _other.GetComponent<GiantController>();
                if (cahceGiant.m_Hands.childCount <= 0)
                {
                    shaderSwap.swapToHighLight();
                    m_Highlight.m_Change = true;
                    m_Model.GetComponent<UIPromptControl>().m_CanInteract = true;
                }
            }
        }

    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (_other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                shaderSwap.swapToStandard();
                m_Highlight.m_Change = false;
                m_Model.GetComponent<UIPromptControl>().m_CanInteract = false;
                m_GiantInRange = false;
            }
        }
    }

    private void Update()
    {
        if (!m_PickedUp)
        {

        }
        else
        {
            m_Highlight.m_Change = false;
            cahceGiant.m_Animation.SetBool("Pushing", true);           
        }
        if (m_GiantInRange && cahceGiant.m_Facing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
            {
                m_Model.transform.parent = cahceGiant.m_Hands;
                m_PickedUp = true;
            }
        }

    }


}
