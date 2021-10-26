using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashableDoor : MonoBehaviour
{
    public bool m_IsOpen = false;

    public Transform m_Pivot;
    public float m_RotationZ = 90.0f;

    public float m_DoorRotateTimer = 0.0f;
    public float cacheRotation;
    AudioSource audio;

    private void Start()
    {
        audio  = GameObject.Find("DoorBreakSFX").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (m_IsOpen && m_DoorRotateTimer <= 1.0f)
        {
            if (m_DoorRotateTimer == 0.0f)
            {
                if (!audio.isPlaying)
                {
                    audio.Play();
                }
            }

            m_DoorRotateTimer += Time.deltaTime * 0.5f;
            float ZRotation = Mathf.Lerp(0.0f, m_RotationZ, m_DoorRotateTimer);
            m_Pivot.rotation = Quaternion.Euler(0.0f, 0.0f, ZRotation);
            cacheRotation = m_Pivot.rotation.z;
        }

        if (cacheRotation>= 0.69f)
        {
            Destroy(gameObject);
        }
    }
}
