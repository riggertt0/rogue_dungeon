using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentScript : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    public float distance_rage;

    public bool aggre = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        NavMeshPath path = new NavMeshPath();
        //agent.CalculatePath(target.position, path);
        //agent.SetDestination(target.position);
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //Debug.Log(aggre);
            //if (agent.remainingDistance <= distance_rage && agent.remainingDistance != 0)
            //{
            if (aggre == false)
            {
                if (agent.remainingDistance <= distance_rage && agent.remainingDistance != 0)
                {
                    aggre = true;
                    agent.isStopped = false;
                    agent.SetDestination(target.position);
                }
                else
                {
                    agent.isStopped = true;
                    agent.SetDestination(target.position);
                }
            }
            else
            {
                
                agent.SetDestination(target.position);
            }

                //Debug.Log("->");

                //Debug.Log(agent.remainingDistance);

            //Debug.Log("-*");
            //}
        }
    }
}
