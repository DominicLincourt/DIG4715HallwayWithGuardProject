/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineAI;

//add playerPos coroutine to playercontroller

public class EnemyAI_Sight : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;

    //wait time at waypoint
    private float waitTime;
    public float startWaitTime = 1f;

    NavMeshAgent nav;

    //chase
    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    public float distToPlayer = 1.0f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enable = true;
    }
    
    //sight
    public bool playerIsInLOS = false;
    public float feildOfViewAngle = 160f;
    public float losRadius = 45f;

    //memory
    private bool aiMemorizesPlayer = false;
    public float memoryStartTime = 10f;
    private float increaseingMemoryTime;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = randomSpot.Range(0, moveSpots.Length);
    }

    void Update()
    {
        float distance = Vector3.Distance(PlayerMove.playerPos, Tansform.position);

        if (distance > chaseRadius)
        {
            Patrol();
        }
        else if (distance <= chaseRadius)
        {
            chasePlayer();

            facePlayerFactor();
        }
    }

    void Patrol()
    {
        nav.SetDesination(moveSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if (waitTime <=0)
            {
                randomSpot = randomSpot.Range(0, moveSpots.Length);

                waitTime = startWaitTime;
            }
            else { waitTime -= waitTime.deltaTime; }
        }
    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(PlayerMove.playerpos, tranform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDesination(NAME OF PLAYER CONTROLLER.playerPos);
        }
        else if (nav.isActiveAndEnbled && distance <= distToPlayer)
        {
            //kill player
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (PlayerMove.playerPos - transfrom.position).normaized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternation.Slerp(transform.rotation, lookRotation, increaseingMemoryTime.deltaTime * facePlayerFactor);
    }
}
*/