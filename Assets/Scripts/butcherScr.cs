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
    public GameObject boy;
    public float dist;
    public Transform targetPosTransform;
    private NavMeshAgent navMeshAgent;
    public bool isRest = true;
    public bool isBeingCtrled = false;
    public bool isSleep = false;
    public bool isIdling = true;

    // for FOV
    public FieldOfView FOV;
    public GameObject detectedUI;
    //for wander
    public bool isWandering = false;
    public float Wanderradius = 6.0f;

    //setup for patroling
    public LayerMask groundMask;
    public Vector3 walkPoint;
    bool walkptSet;
    public float walkPointRange;

    //animator
    public Animator butcherAnim;

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
        if(isIdling)
        {
            
        }
        else if (isSleep == false && isBeingCtrled == false)
        {
            butcherMove();
            detectBoy();
            butcherAnim.SetBool("Walking", true);
        }
    }

    void butcherMove()
    {
        if(isRest == true)
        {
            if(isWandering == false)
            {
                isWandering = true;
                navMeshAgent.isStopped = true;
                navMeshAgent.ResetPath();
            }

            if (currRest > 0)
            {

                if (isWandering == true && !navMeshAgent.hasPath )
                {
                    //wandering
                    print("Butcher is roaming");
                    if(navMeshAgent.isStopped == true)
                    {
                        navMeshAgent.isStopped = false;
                    }
                    
                    navMeshAgent.SetDestination(GetRandPoint.Instance.GetRandomPoint(transform, Wanderradius));
                }
                currRest -= Time.deltaTime;
            }
            else
            {
                currRest = 0;
                isRest = false;
                isWandering = false;
                currChase = maxChase;
                targetPosTransform = boy.transform;
            }
        }
        else
        {
            
            navMeshAgent.isStopped = false;
            print("agent waked");
            navMeshAgent.destination = targetPosTransform.position;
            currChase -= Time.deltaTime;
            print("time subbed");
            if (currChase <= 0)
            {
                currChase = 0;
                currRest = maxRest;
                isRest = true;
            }

        }

    }

    void Patroling()
    {
        if(!walkptSet)
        {
            FindWalkPoint();
        }

        if(walkptSet)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.ResetPath();
            navMeshAgent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPt = transform.position - walkPoint;

        //if reached patrol point
        if(distanceToWalkPt.magnitude < 1f)
        {
            walkptSet = false;
        }
    }

    void FindWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint,-transform.up,2f,groundMask))
        {
            walkptSet = true;
        }
    }

    void detectBoy()
    {
        dist = Vector3.Distance(boy.transform.position, transform.position);
        if(dist <= 2.95f && FOV.canSeePlayer == true)
        {
            //detected boy
            print("boy detected!");
            detectedUI.SetActive(true);
        }
        else
        {
            detectedUI.SetActive(false);
        }
    }



}
