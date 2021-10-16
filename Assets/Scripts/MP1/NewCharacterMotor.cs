﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterMotor : MonoBehaviour
{
    [Header("Character Motor Components")]
    public MouseLook m_Look;

    public Transform m_Model;

    public CharacterController m_Controller;

    public Vector3 m_Velocity;

    public float m_MoveSpeed = 8.0f;
    public float m_Acceleration = 12.0f;
    public AnimationCurve m_FrictionCurve = AnimationCurve.Linear(0.0f, 0.1f, 1.0f, 1.0f);

    public float m_Gravity = 40.0f;
    public float m_JumpSpeed = 12.0f;
    public bool m_Grounded = false;

    public float m_FacingAngle = 0.0f;

    public Camera m_Camera;

    public Animator m_Animation;

    public AudioSource m_AudioSource;

    //Control
    public bool m_IsGiant = false;
    public bool m_IsControl = false;

    //Crouching
    public bool m_IsCrouching = false;

    protected virtual void Update()
    {
        float x = 0.0f;
        float z = 0.0f;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && m_Grounded && !m_IsGiant)
        {
            m_Velocity.y = m_JumpSpeed;
            m_Animation.ResetTrigger("Jump");
            m_Animation.SetTrigger("Jump");
            m_AudioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && m_Grounded && !m_IsGiant)
        {
            if ((m_Controller.collisionFlags & CollisionFlags.Above) == 0)
            {
                m_IsCrouching = !m_IsCrouching;
            }
        }

        if (m_IsCrouching)
        {
            m_Controller.height = 1.0f;
            m_Model.transform.localPosition = new Vector3(0, 0.5f, 0);
        }
        else
        {
            m_Controller.height = 2.0f;
            m_Model.transform.localPosition = Vector3.zero;
        }

        Vector3 inputMove = new Vector3(x, 0.0f, z);
        inputMove = Quaternion.Euler(0.0f, m_Camera.transform.eulerAngles.y, 0.0f) * inputMove;
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

        if (m_Velocity.x == 0)
        {
            m_Animation.SetBool("Walking", false);
        }
        else
        {
            m_Animation.SetBool("Walking", true);
        }

        Vector3 trueVelocity = m_Velocity;
        trueVelocity.x *= m_MoveSpeed;
        trueVelocity.z *= m_MoveSpeed;

        m_Controller.Move(trueVelocity * Time.deltaTime);

        GroundCheck();

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

    protected void GroundCheck()
    {
        if ((m_Controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            m_Velocity.y -= 1.0f;
            m_Grounded = true;
            m_Velocity.y = 0.0f;
        }
        else
        {
            m_Grounded = false;
        }

        if ((m_Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            m_Velocity.y = -1.0f;
        }
    }
}