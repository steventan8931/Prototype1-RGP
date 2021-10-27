using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantOneAI : MonoBehaviour
{
    GiantController m_GiantController;
    public bool m_Reading = false;
    public bool m_LookingAround = false;
    public bool m_Controllable = false;

    public float m_ReadingTimer = 0.0f;
    public float m_LookAroundAtTime = 15.0f;
    public float m_LookAroundTimer = 0.0f;
    public float m_LookAroundTime = 4.0f;

    public GameObject m_ScoutingCone;
    public bool m_ScoutingLeft = false;
    public float m_ScoutRotation = 0.0f;
    public float m_ScoutSpeed = 10.0f;
    public Vector2 m_ScoutRotationExtents = new Vector2(-80.0f, 80.0f);

    public FieldOfView FOV;

    public GameObject m_Book;
    private void Start()
    {
        m_GiantController = GetComponent<GiantController>();
        FOV = GetComponent<FieldOfView>();
    }

    private void Update()
    {
        m_Controllable = m_GiantController.m_Controllable;
        if (!m_Controllable)
        {
            if (m_Reading)
            {
                m_ScoutingCone.SetActive(false);
                Reading();
                m_ReadingTimer += Time.deltaTime;
                if (m_ReadingTimer > m_LookAroundAtTime)
                {
                    m_ReadingTimer = 0.0f;
                    m_LookingAround = true;
                    m_Reading = false;
                }
            }
            if (m_LookingAround)
            {
                m_ScoutingCone.SetActive(true);
                LookingAround();
                m_LookAroundTimer += Time.deltaTime;
                if(FOV.canSeePlayer)
                {
                    FailFunc();
                }
                if (m_LookAroundTimer > m_LookAroundTime)
                {
                    m_LookAroundTimer = 0.0f;
                    m_Reading = true;
                    m_LookingAround = false;
                    m_ScoutRotation = 0.0f;
                }
            }

        }
        else
        {
            m_Book.SetActive(false);
            m_ScoutingCone.SetActive(false);
            m_GiantController.m_Animation.SetBool("Reading", false);
            m_GiantController.m_Animation.SetBool("LookAround", false);
            m_GiantController.m_Model.localPosition = Vector3.zero;
        }
    }

    public void Reading()
    {
        m_GiantController.m_Model.localPosition = new Vector3(-0.299f, 0.102f, -0.133f);

        m_GiantController.m_Animation.SetBool("Reading", true);
        m_GiantController.m_Animation.SetBool("LookAround", false);
    }

    public void LookingAround()
    {
        m_GiantController.m_Animation.SetBool("Reading", false);
        m_GiantController.m_Animation.SetBool("LookAround", true);

        ////Update with actual FOV
        //if (m_ScoutRotation >= m_ScoutRotationExtents.y)
        //{
        //    m_ScoutingLeft = true;

        //}
        //if (m_ScoutRotation <= m_ScoutRotationExtents.x)
        //{
        //    m_ScoutingLeft = false;

        //}
        //if (m_ScoutingLeft)
        //{
        //    m_ScoutRotation -= Time.deltaTime * m_ScoutSpeed;
        //}
        //else
        //{
        //    m_ScoutRotation += Time.deltaTime * m_ScoutSpeed;
        //}

        //m_ScoutingCone.transform.localRotation = Quaternion.Euler(-70, m_ScoutRotation, m_ScoutingCone.transform.localRotation.y);

    }

    public void  FailFunc()
    {
        //teleport player away
    }
    
}
