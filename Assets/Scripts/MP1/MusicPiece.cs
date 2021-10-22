using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPiece : MonoBehaviour
{
    AudioSource m_Audio;
    public Camera m_Camera;
    Renderer m_Renderer;
    bool m_Triggered = false;
    public float m_CameraSwitchTime = 0.0f;
    public float m_CameraSwitchTimer = 1.0f;
    Boy cacheBoy;
    Camera[] m_Cameras;

    private void Start()
    {
        m_Audio = GameObject.Find("MusicPieceSFX").GetComponent<AudioSource>();
        m_Renderer = GetComponent<Renderer>();
        m_Cameras = FindObjectsOfType<Camera>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Animation.SetTrigger("PickUp");
            if (_other.GetComponent<Boy>() != null)
            {
                m_Renderer.enabled = false;
                cacheBoy = _other.GetComponent<Boy>();
                m_Triggered = true;
                m_Audio.Play();
                //foreach (Camera cams in m_Cameras)
                //{
                //    cams.enabled = false;
                //}
                //m_Camera.enabled = true;
                _other.GetComponent<Boy>().m_MusicPieceCollected = true;
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        //if (m_Triggered)
        //{
        //    if (m_Camera.enabled)
        //    {
        //        m_CameraSwitchTime += Time.deltaTime;

        //        if (m_CameraSwitchTime > m_CameraSwitchTimer)
        //        {
        //            foreach (Camera cams in m_Cameras)
        //            {
        //                cams.enabled = false;
        //            }
        //            cacheBoy.m_Look.m_AttachedCamera.enabled = true;
        //            Destroy(gameObject);
        //        }
        //    }
        //}
    }
}
