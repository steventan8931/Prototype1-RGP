using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public bool m_KeyCollected = false;

    public int m_RoomsCleared = 0;

    public bool m_GameWon = false;

    public Transform[] m_Checkpoints;

    public bool m_Detected = false;
    public bool m_Killed = false;

    public float m_RespawnTimer = 0.0f;
    public float m_RespawnDelay = 0.5f;

    public Transform m_Hands;

    private void Update()
    {
        if (m_Detected || m_Killed)
        {
            m_RespawnTimer += Time.deltaTime;
            if (m_RespawnTimer > m_RespawnDelay)
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = m_Checkpoints[m_RoomsCleared].position;
                GetComponent<CharacterController>().enabled = true;
                m_RespawnTimer = 0;
                m_Detected = false;
                m_Killed = false;
            }
        }

        //Pick Up
        if (m_Hands.childCount > 0)
        {
            //GetComponent<CharacterMotor>().m_Animation.SetBool("PushHigh", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("release");
                m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                if (m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_RotationLocked)
                {
                    m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
                m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_PickedUp = false;
                m_Hands.GetChild(0).transform.parent = null;
            }
        }
    }


}
