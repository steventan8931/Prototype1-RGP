using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public Transform m_Model;

    public MouseLook m_Look;

    public CharacterController m_Controller;

    public Vector3 m_Velocity;

    public float m_MoveSpeed = 8.0f;
    public float m_Acceleration = 12.0f;
    public AnimationCurve m_FrictionCurve = AnimationCurve.Linear(0.0f, 0.1f, 1.0f, 1.0f);

    public float m_Gravity = 40.0f;
    public float m_JumpSpeed = 12.0f;

    public float m_PushStrength = 5.0f;

    public bool m_Grounded = false;

    public float m_FacingAngle = 0.0f;

    public bool m_IsGiant = false;

    public bool m_IsControl = true;

    public bool m_ScoutingLeft = false;
    public float m_ScoutTimer = 0.0f;
    public float m_ScoutRotation = 0.0f;
    public float m_ScoutSpeed = 10.0f;
    public Vector2 m_ScoutRotationExtents = new Vector2(-45.0f, 45.0f);

    public Animator m_Animation;

    public bool m_JumpPressed = false;
    public float m_JumpDelay = 0.2f;
    public float m_JumpDelayTimer = 0.0f;
    public bool m_IsChanging = false;

    public void Start()
    {
        m_Look.m_AttachedCamera.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit _hit)
    {
        if (m_IsGiant)
        {
            Vector3 horizontalVelocity = m_Velocity;
            horizontalVelocity.y = 0.0f;

            if (_hit.moveDirection.y < -0.3f)
            {
                return;
            }

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
                            m_Animation.SetBool("PushLow", true);
                        }
                        else
                        {
                            m_Animation.SetBool("PushHigh", true);
                        }
                    }

                }
            }
        }
    }

    public void Update()
    {
        float x = 0.0f;
        float z = 0.0f;

        if (m_IsControl)
        {
            m_Look.ManagedUpdate();

            x = Input.GetAxisRaw("Horizontal");

            z = Input.GetAxisRaw("Vertical");

            if (m_JumpPressed)
            {
                m_JumpDelayTimer += Time.deltaTime;
                if (m_JumpDelayTimer > m_JumpDelay)
                {
                    m_Velocity.y = m_JumpSpeed;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_Grounded && !m_IsGiant && m_JumpDelayTimer <= 0.0f)
            {
                m_Animation.ResetTrigger("Jump");
                m_Animation.SetTrigger("Jump");
                m_JumpPressed = true;

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                //m_Animation.ResetTrigger("Jump");
            }



        }
        else
        {
            if (m_IsGiant)
            {
                if (GetComponent<Giant>().m_Controllable == false)
                {
                    if (m_ScoutRotation >= m_ScoutRotationExtents.y)
                    {
                        m_ScoutingLeft = true;

                    }
                    if (m_ScoutRotation <= m_ScoutRotationExtents.x)
                    {
                        m_ScoutingLeft = false;

                    }
                    if (m_ScoutingLeft)
                    {
                        m_ScoutRotation -= Time.deltaTime * m_ScoutSpeed;
                    }
                    else
                    {
                        m_ScoutRotation += Time.deltaTime * m_ScoutSpeed;
                    }

                    m_Model.localEulerAngles = new Vector3(0.0f, m_FacingAngle + m_ScoutRotation, 0.0f);
                }

            }
        }

        Vector3 inputMove = new Vector3(x, 0.0f, z);
        inputMove = Quaternion.Euler(0.0f, m_Look.m_Spin, 0.0f) * inputMove;
        if (inputMove.sqrMagnitude > 1.0f)
        {
            inputMove.Normalize();
        }

        float cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;

        Vector3 cacheVelocity = m_Velocity;

        m_Velocity += inputMove * m_Acceleration * Time.deltaTime;
        m_Velocity -= m_Velocity.normalized * m_Acceleration * m_FrictionCurve.Evaluate(m_Velocity.magnitude) * Time.deltaTime;

        if (Vector3.Dot(cacheVelocity.normalized, m_Velocity.normalized) < 0.0f)
        {
            m_Velocity.x = 0.0f;
            m_Velocity.z = 0.0f;
        }

        m_Velocity.y = cacheY;
        m_Velocity.y -= m_Gravity * Time.deltaTime;

        if (m_IsGiant)
        {
            if (m_Velocity.x == 0)
            {
                m_Animation.SetBool("Walking", false);
                m_Animation.SetBool("PushHigh", false);
                m_Animation.SetBool("PushLow", false);
            }
            else
            {
                m_Animation.SetBool("Walking", true);
            }
        }
        else
        {
            if (m_Velocity.x == 0)
            {
                m_Animation.SetBool("Running", false);
                GetComponent<CharacterMotor>().m_Animation.SetBool("Pushing", false);
            }
            else
            {
                m_Animation.SetBool("Running", true);
            }
        }

        Vector3 trueVelocity = m_Velocity;
        trueVelocity.x *= m_MoveSpeed;
        trueVelocity.z *= m_MoveSpeed;

        m_Controller.Move(trueVelocity * Time.deltaTime);

        if ((m_Controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            m_Velocity.y = -1.0f;
            m_Grounded = true;
        }
        else
        {
            m_Grounded = false;
            m_JumpPressed = false;
            m_JumpDelayTimer = 0;

        }

        if ((m_Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            m_Velocity.y = -1.0f;
        }

        cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;
        if (m_Velocity.magnitude > 0.01f)
        {
            float angle = Mathf.Atan2(m_Velocity.x, m_Velocity.z) * Mathf.Rad2Deg;
            m_Model.localEulerAngles = new Vector3(0.0f, angle, 0.0f);
            m_FacingAngle = angle;
        }
        m_Velocity.y = cacheY;


    }
}
