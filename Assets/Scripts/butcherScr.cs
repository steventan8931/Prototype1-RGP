using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class butcherScr : MonoBehaviour
{
    public float currChase = 0;
    public float maxChase = 10;
    public float currRest = 0;
    public float maxRest = 15;
    [SerializeField] private Transform targetPosTransform;
    private NavMeshAgent navMeshAgent;
    public bool isRest = true;
    public bool isBeingCtrled = false;
    public bool isSleep = false;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSleep == false && isBeingCtrled == false)
        {
            butcherMove();
        }
    }

    void butcherMove()
    {
        if(isRest == true)
        {
            if(currRest > 0)
            {
                currRest -= Time.deltaTime;
            }
            else
            {
                currRest = 0;
                isRest = false;
                currChase = maxChase;
            }
        }else
        {
            navMeshAgent.destination = targetPosTransform.position;
            currChase -= Time.deltaTime;
            if (currChase <= 0)
            {
                currChase = 0;
                currRest = maxRest;
                isRest = true;
            }

        }

    }
}
