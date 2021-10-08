using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{
    public GameObject m_Model;

    public bool m_PickedUp = false;
    public bool m_GiantItem = true;
    public bool m_RotationLocked = false;

    //NEW PICKUPABLE
    public bool m_BoyInRange = false;
    public bool m_GiantInRange = false;
    GiantController cahceGiant;
    Boy cacheBoy;
    bool go = false;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (m_GiantItem && _other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                m_GiantInRange = true;
                cahceGiant = _other.GetComponent<GiantController>();
            }
        }

        if (_other.tag == "Boy")
        {
            if (!m_GiantItem && !_other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
                {
                    m_BoyInRange = true;
                    cacheBoy = _other.GetComponent<Boy>();
                }
            }
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (m_GiantItem && _other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                m_GiantInRange = false;
            }
        }

        if (_other.tag == "Boy")
        {
            if (!m_GiantItem && !_other.GetComponent<CharacterSwapper>().m_IsGiant)
            {
                m_BoyInRange = false;
            }
        }
    }

    private void Update()
    {
        if (!m_PickedUp)
        {
            //m_Model.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            m_Model.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            cahceGiant.m_Animation.SetBool("PushHigh", true);
            cahceGiant.m_Animation.SetBool("PushLow", false);
            m_Model.transform.localPosition = Vector3.Lerp(m_Model.transform.localPosition, new Vector3(m_Model.transform.localPosition.x, 0, m_Model.transform.localPosition.z), Time.deltaTime * 2);
        }
        if (m_GiantInRange && cahceGiant.m_Facing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
            {
                //m_Model.transform.parent = cahceGiant.m_Hands;
                //m_Model.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
                //m_Model.transform.localPosition = new Vector3(m_Model.transform.localPosition.x, 0, m_Model.transform.localPosition.z);
                //m_Model.transform.GetChild(0).transform.localPosition = Vector3.zero;
                m_Model.transform.parent = cahceGiant.m_Hands;
                m_Model.transform.GetComponent<Rigidbody>().isKinematic = true;
               // m_Model.transform.localPosition = new Vector3(m_Model.transform.localPosition.x, 0, m_Model.transform.localPosition.z);
                m_PickedUp = true;
            }
        }

        if(m_BoyInRange)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
            {
                m_Model.transform.parent = cacheBoy.m_Hands;
                //m_Model.transform.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                //m_Model.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                m_PickedUp = true;
            }
        }
    }

    
}
