using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPiece : MonoBehaviour
{
    AudioSource m_Audio;
    public GameObject m_Camera;
    Renderer m_Renderer;
    bool m_Triggered = false;
    public float m_CameraSwitchTime = 0.0f;
    public float m_CameraSwitchTimer = 1.0f;
    Boy cacheBoy;

    private void Start()
    {
        m_Audio = GameObject.Find("MusicPieceSFX").GetComponent<AudioSource>();
        m_Renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Animation.SetTrigger("PickUp");
            if (_other.GetComponent<Boy>() != null)
            {
                m_Camera.SetActive(true);
                cacheBoy = _other.GetComponent<Boy>();
                m_Triggered = true;
                m_Audio.Play();
                _other.GetComponent<Boy>().m_MusicPieceCollected = true;
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {

    }
}
