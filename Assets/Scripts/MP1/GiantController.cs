using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantController : NewCharacterMotor
{
    [Header("Giant Controller Components")]
    public Transform m_Hands;
    public bool m_Controllable = false;

    public float m_PushStrength = 5.0f;
    public bool m_Facing = false;

    public bool m_IsBaby = false;

    private void Start()
    {
        m_IsGiant = true;
        m_Hands.gameObject.SetActive(true);
        if (m_IsBaby)
        {
            m_Animation.speed = 0.0f;
        }

        //m_Controllable = false;
    }

    protected override void Update()
    {
        if (m_IsControl)
        {
            if (m_Velocity.x == 0)
            {
                if (m_IsBaby)
                {
                    m_Animation.speed = 0.0f;
                }
                else
                {
                    m_Animation.speed = 1.0f;
                }

                if (!m_IsBaby)
                {
                    m_Animation.SetBool("Pushing", false);
                    m_Animation.SetBool("Holding", false);
                }

                m_Facing = false;
            }
            else
            {
                m_Animation.speed = 1.0f;
            }
            base.Update();
            //Pick Up
            if (m_Hands.childCount > 0 && !m_IsBaby)
            {
                m_Animation.SetBool("Pushing", true);

                m_CanStrafe = false;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    m_CanStrafe = true;
                    m_Hands.GetChild(0).GetChild(0).GetComponent<PullableObject>().m_PickedUp = false;
                    m_Hands.GetChild(0).transform.parent = null;
                }
            }
        }
        else
        {
            //m_Animation.SetBool("Walking", false);
            //m_Animation.SetBool("Pushing", false);
            //m_Animation.SetBool("Holding", false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit _hit)
    {
        if(m_IsBaby)
        {
            return;
        }

        Vector3 horizontalVelocity = m_Velocity;
        horizontalVelocity.y = 0.0f;

        if (_hit.moveDirection.y < -0.3f)
        {
            return;
        }

        m_Facing = true;

        if (_hit.collider.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rigid = _hit.collider.GetComponent<Rigidbody>();
            if (horizontalVelocity.x != 0)
            {
                rigid.AddForce(horizontalVelocity * m_PushStrength);
                if (_hit.collider.GetComponent<PushableObject>() != null)
                {
                    if (_hit.collider.GetComponent<PushableObject>().m_IsBig == false)
                    {
                        m_Animation.SetBool("Pushing", true);
                    }
                    else
                    {
                        m_Animation.SetBool("Pushing", true);
                    }
                }

            }
        }
    }
}
