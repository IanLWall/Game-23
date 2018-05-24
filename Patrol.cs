using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject player;
    //public GameObject darkness;
    //public GameObject safeSpace;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        else if (Vector3.Distance(this.transform.position, player.transform.position) <= 5 && !player.GetComponent<Player>().isHidden)
        {
            //darkness.SetActive(true);
            agent.destination = player.transform.position;
            
        }
    }
    //void onTriggerEnter (Collider safeSpace)
    //{
    //    darkness.SetActive(false);
    //    agent.destination = points[destPoint].position;
    //    print ("Hidden");
    //}
}
