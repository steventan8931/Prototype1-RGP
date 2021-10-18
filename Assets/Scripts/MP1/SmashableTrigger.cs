using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashableTrigger : MonoBehaviour
{
    public GameObject m_Model;

    public bool m_GiantInRange = false;
    GiantController cahceGiant;
    HighlightObject m_Highlight;

    public SmashableDoor m_Door;
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
                m_Highlight.m_Change = false;
                m_Model.GetComponent<UIPromptControl>().m_CanInteract = false;
                m_GiantInRange = false;
            }
        }
    }

    private void Update()
    {
        if (m_GiantInRange && cahceGiant.m_Facing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                cahceGiant.m_Animation.SetBool("Pushing", true);
                m_Door.m_IsOpen = true;
            }
        }
    }
}
