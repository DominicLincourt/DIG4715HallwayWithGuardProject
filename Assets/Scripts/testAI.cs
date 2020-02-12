using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class testAI : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;
        destPoint = 1;

        
    }


    void GotoNextPoint()
    {
        
        // Returns if no points have been set up
        if (agent.destination != points[destPoint].position)
        {
            StartCoroutine(MyWaitMethod());
            agent.destination = points[destPoint].position;
        }

        // Set the agent to go to the currently selected destination.
        
        //Debug.Log("I'm headed to: " + agent.destination);

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        Debug.Log("I'm at: " + destPoint);
    }

    IEnumerator MyWaitMethod()
    {
        agent.speed = 0;
        Debug.Log("wait 3");
        yield return new WaitForSeconds(3);
        
        agent.speed = 2;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}