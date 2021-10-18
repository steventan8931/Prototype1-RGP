using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : NewCharacterMotor
{
    [Header("Boy Components")]
    public bool m_KeyCollected = false;

    public int m_RoomsCleared = 0;

    public bool m_GameWon = false;

    public Transform[] m_Checkpoints;

    public bool m_Detected = false;
    public bool m_Killed = false;

    public float m_RespawnTimer = 0.0f;
    public float m_RespawnDelay = 0.5f;

    public Transform m_Hands;

    public ScoutingCone m_ScoutingScone;

    //Climbing
    public bool m_CanClimb = false;
    public bool m_IsClimbing = false;
    public bool m_ZHorizontal = false;
    public float m_ClimbSpeed = 20.0f;

    //Collectables
    public bool m_MusicPieceCollected = false;

    //Riding Baby
    public bool m_IsRiding = false;

    protected override void Update()
    {
        if (m_IsRiding)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_IsRiding = false;
            }
            return;
        }

        if (m_IsControl)
        {
            if (m_CanClimb)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_IsClimbing = !m_IsClimbing;
                }
            }

            if (m_IsClimbing)
            {
                Climb();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_IsClimbing = false;
                }
            }
            else
            {
                base.Update();
            }

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
                    m_ScoutingScone.m_Audio.Stop();
                }
            }

            //Pick Up
            if (m_Hands.childCount > 0)
            {
                m_Animation.SetBool("Pushing", true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
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
        else
        {
            m_Animation.SetBool("Walking", false);
            m_Velocity.y -= m_Gravity * Time.deltaTime;
            Vector3 trueVelocity = new Vector3(0.0f, m_Velocity.y, 0.0f);
            m_Controller.Move(trueVelocity * Time.deltaTime);
            GroundCheck();
        }

    }


    void Climb()
    {
        float x = 0.0f;
        float z = 0.0f;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 inputMove;

        if (m_ZHorizontal)
        {
            inputMove = new Vector3(0.0f, z, x);
        }
        else
        {
            inputMove = new Vector3(x, z, 0.0f);
        }

        m_Velocity = inputMove * m_Acceleration * Time.deltaTime;

        Vector3 trueVelocity = m_Velocity;
        trueVelocity.y *= m_ClimbSpeed;

        if (m_ZHorizontal)
        {
            trueVelocity.z *= m_ClimbSpeed;
        }
        else
        {
            trueVelocity.x *= -m_ClimbSpeed;
        }

        m_Controller.Move(trueVelocity * Time.deltaTime);
        if (m_Velocity.magnitude > 0.01f)
        {
            float angle = Mathf.Atan2(m_Velocity.x, m_Velocity.z) * Mathf.Rad2Deg;
            //m_Model.localEulerAngles = new Vector3(0.0f, angle, 0.0f);
            m_FacingAngle = angle;
        }
    }

}
