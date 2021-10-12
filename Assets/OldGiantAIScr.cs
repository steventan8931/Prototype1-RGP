using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OldGiantAIScr : MonoBehaviour
{
    public GameObject boy;
    public Transform targetPosTransform;
    private NavMeshAgent navMeshAgent;
    public bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        boy = GameObject.FindGameObjectWithTag("Boy");
        targetPosTransform = boy.transform;
    }

    public void oldGiantChase()
    {
        navMeshAgent.destination = targetPosTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
