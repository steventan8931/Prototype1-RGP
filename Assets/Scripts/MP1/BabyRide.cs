using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRide : MonoBehaviour
{
    public GameObject UIControl;

    public bool m_PickedUp = false;
    public bool m_BoyInRange = false;
    public GiantController cahceGiant;
    Boy cacheBoy;
    HighlightObject m_Highlight;

    weeBabyScr m_Baby;

    private void Start()
    {
        m_Highlight = UIControl.GetComponent<HighlightObject>();
        cacheBoy = FindObjectOfType<Boy>();
        m_Baby = FindObjectOfType<weeBabyScr>();
    }

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>())
            {
                m_BoyInRange = true;
                m_Highlight.m_Change = true;
                UIControl.GetComponent<UIPromptControl>().m_CanInteract = true;
            }
        }

    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>())
            {
                m_Highlight.m_Change = false;
                UIControl.GetComponent<UIPromptControl>().m_CanInteract = false;
                m_BoyInRange = false;
            }
        }
    }

    private void Update()
    {
        if(!m_Baby.GetComponent<GiantController>().m_Controllable)
        {
            return;
        }
        if (!cacheBoy.m_IsRiding)
        {

        }
        else
        {
            m_Highlight.m_Change = false;

        }
        if (m_BoyInRange)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                cacheBoy.transform.parent = cahceGiant.m_Hands;
                cacheBoy.transform.localPosition = Vector3.zero;
                cacheBoy.m_Model.localRotation = Quaternion.Euler(Vector3.zero);
                cacheBoy.m_IsRiding = true;
                m_PickedUp = true;
            }
        }

    }

}
