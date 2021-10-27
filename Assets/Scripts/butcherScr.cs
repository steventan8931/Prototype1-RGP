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
    public Transform targetPosTransform;
    private NavMeshAgent navMeshAgent;
    public bool isRest = true;
    public bool isBeingCtrled = false;
    public bool isSleep = false;
    public bool isIdling = true;
    //for wander
    public bool isWandering = false;
    public float Wanderradius = 6.0f;
    public Transform loc1, loc2, loc3,loc4;
    public int wandertarget = 1;

    //setup for patroling
    public LayerMask groundMask;
    public Vector3 walkPoint;
    bool walkptSet;
    public float walkPointRange;

    //animator
    public Animator butcherAnim;

    //GiantController
    public GiantController m_Giant;
    public GameObject m_ScoutingCone;
    //for table push
    public GameObject table;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        m_Giant = GetComponent<GiantController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_ScoutingCone.SetActive(true);
        isIdling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Giant.m_Controllable)
        {
            isIdling = true;
            m_ScoutingCone.SetActive(false);
            transform.rotation = Quaternion.Euler(Vector3.zero);
            navMeshAgent.enabled = false;
            table.GetComponent<Rigidbody>().isKinematic = false;
            
        }
        if(isIdling)
        {
            if (!isSleep)
            {
                butcherAnim.SetBool("Walking", false);
                isSleep = true;
            }
        }
        else if (isSleep == false && isBeingCtrled == false && isIdling == false)
        {
            butcherMove2();
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
                    //print("Butcher is roaming");
                    if(navMeshAgent.isStopped == true)
                    {
                        navMeshAgent.isStopped = false;
                    }
                    if(wandertarget == 1)
                    {
                        navMeshAgent.SetDestination(loc1.position);
                        wandertarget = 2;
                    }else if(wandertarget == 2)
                    {
                        navMeshAgent.SetDestination(loc2.position);
                        wandertarget = 3;
                    }
                    else if (wandertarget == 3)
                    {
                        navMeshAgent.SetDestination(loc3.position);
                        wandertarget = 4;
                    }
                    else if (wandertarget == 4)
                    {
                        navMeshAgent.SetDestination(loc4.position);
                        wandertarget = 1;
                    }

                }
                //m_ScoutingCone.SetActive(false); //Have scotuing cone always on
                //currRest -= Time.deltaTime;
            }
            else
            {
                currRest = 0;
                isRest = false;
                isWandering = false;
                currChase = maxChase;
                targetPosTransform = boy.transform;
                m_ScoutingCone.SetActive(true);
            }
        }
        else
        {
            //targetPosTransform = boy.transform;
            navMeshAgent.isStopped = true;
            navMeshAgent.ResetPath();
            navMeshAgent.isStopped = false;
            //print("agent waked");
            navMeshAgent.destination = targetPosTransform.position;
            currChase -= Time.deltaTime;
            //print("time subbed");
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
    void butcherMove2()
    {
        if(boy.GetComponent<Boy>().m_MusicPieceCollected == false)
        {

            if (!navMeshAgent.hasPath)
            {
                //wandering
                //print("Butcher is roaming");
                if (navMeshAgent.isStopped == true)
                {
                    navMeshAgent.isStopped = false;
                }
                if (wandertarget == 1)
                {
                    navMeshAgent.SetDestination(loc1.position);
                    wandertarget = 2;
                }
                else if (wandertarget == 2)
                {
                    navMeshAgent.SetDestination(loc2.position);
                    wandertarget = 3;
                }
                else if (wandertarget == 3)
                {
                    navMeshAgent.SetDestination(loc3.position);
                    wandertarget = 4;
                }
                else if (wandertarget == 4)
                {
                    navMeshAgent.SetDestination(loc4.position);
                    wandertarget = 1;
                }

            }
        }
        else
        {
            targetPosTransform = boy.transform;
            navMeshAgent.isStopped = false;
            //print("agent waked");
            navMeshAgent.destination = targetPosTransform.position;
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



}
