using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public MouseLook m_Look;

    public CharacterController m_Controller;

    public Vector3 m_Velocity;

    public float m_MoveSpeed = 8.0f;
    public float m_Acceleration = 12.0f;
    public AnimationCurve m_FrictionCurve = AnimationCurve.Linear(0.0f, 0.1f, 1.0f, 1.0f);

    public float m_Gravity = 40.0f;
    public float m_JumpSpeed = 12.0f;

    public bool m_Grounded = false;

    public void Start()
    {
        m_Look.m_AttachedCamera.enabled = true;
    }

    public void Update()
    {
        m_Look.ManagedUpdate();

        float x = 0.0f;
        x = Input.GetAxisRaw("Horizontal");
        float z = 0.0f;
        z = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && m_Grounded)
        {
            m_Velocity.y = m_JumpSpeed;
            Debug.Log(m_Velocity.y);
            m_Grounded = false;
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
        }

        if ((m_Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            m_Velocity.y = -1.0f;
        }

        cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;
        m_Velocity.y = cacheY;
    }
}
