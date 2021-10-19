using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                _other.GetComponent<Boy>().m_MusicPieceCollected = true;
                _other.GetComponent<Boy>().m_Animation.SetTrigger("PickUp");
                Destroy(gameObject);
            }
        }
    }
}
