using System;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMoving : MonoBehaviour
{
    private NavMeshAgent agent;

    private BasicAI manager;

    private bool hasCommand = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // manager = FindObjectOfType<BasicAI>();
        manager = FindFirstObjectByType<BasicAI>();
        // manager = FindAnyObjectByType<BasicAI>();
        if (agent == null)
        {
            Debug.LogWarning(
                gameObject.name +
                " does not have a NavMeshAgent."
            );
        }

        if (manager == null)
        {
            Debug.LogWarning(
                "BasicAI could not be found."
            );
        }
    }

    void Update()
    {
        if(hasCommand &&
            agent != null)
        {
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                hasCommand = false;
                if (manager != null)
                {

                    manager.ReceiveRobotReport(gameObject.name,
                                           "Destination Reached");
                }
            }
        }
    }

// Move
    public void MoveCommand(Vector3 target)
    {
        if (agent == null)
        {
            Debug.LogWarning(
                gameObject.name +
                " cannot move because it has no NavMeshAgent."
            );

            return;
        }

        agent.SetDestination(target);

        hasCommand = true;

        Debug.Log(gameObject.name +
                  " moving to " + target);
    }

    public void ReceiveMessage(string message)
    {
        Debug.Log(gameObject.name +
                  " received: " + message);
    }

    public Vector3 GetRobotPosition()
    {
        return transform.position;
    }

    public void ReportPosition()
    {
        if (manager != null)
        {
            manager.ReceiveRobotPosition(
                gameObject.name,
                transform.position);
        }
    }
}