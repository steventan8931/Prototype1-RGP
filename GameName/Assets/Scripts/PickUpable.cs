using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{
    public GameObject m_Model;

    public bool m_PickedUp = false;
    public bool m_GiantItem = true;
    public bool m_RotationLocked = false;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (m_GiantItem)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
                {
                    m_Model.transform.parent = _other.GetComponent<Giant>().m_Hands;

                    m_Model.transform.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    m_Model.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                    m_PickedUp = true;
                }
            }
        }

        if (_other.tag == "Boy")
        {
            if (!m_GiantItem)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
                {
                    m_Model.transform.parent = _other.GetComponent<Boy>().m_Hands;

                    m_Model.transform.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    m_Model.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                    m_PickedUp = true;
                }
            }
        }
    }
}
