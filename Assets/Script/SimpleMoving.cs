//     // Fisrt script:

// using System;
// using UnityEngine;
// using UnityEngine.AI;

// public class SimpleMoving : MonoBehaviour
// {
//     NavMeshAgent agent;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {

//         agent = GetComponent<NavMeshAgent>();

//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//         // check if we received any commands from our main AI
//         // do stuff for those commands
//         // send any information back to the main AI that we need to send
//         //   -> our position
//         //   -> any updates (e.g. we cleared an obstacle)


//         NavMeshPath path = new NavMeshPath();
//         agent.CalculatePath(new Vector3(7, 0, -9), path);
//         agent.SetPath(path);

//     }


//     // public void MoveCommand() { }

//     // public void AddToCommandQueue() { }

//     // public void ReceiveMessage(string message)
//     // {
//     //     Console.WriteLine(message);
//     // }
// }




// // Second script:

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

        manager = FindObjectOfType<BasicAI>();
        // manager = FindFirstObjectByType<BasicAI>();
        // manager = FindAnyObjectByType<BasicAI>();
    }

    void Update()
    {
        if(hasCommand)
        {
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                hasCommand = false;

                manager.ReceiveRobotReport(gameObject.name,
                                           "Destination Reached");
            }
        }
    }

// Move
    public void MoveCommand(Vector3 target)
    {
        agent.SetDestination(target);

        hasCommand = true;

        Debug.Log(gameObject.name +
                  " moving to " + target);
    }

// // You should extend SimpleMoving when the robot needs to perform an action after arriving or change its behavior.

// // Search
// public void Search()
// {
//     Debug.Log(gameObject.name + " is searching the area.");
// }

// // Rescue
// public void Rescue()
// {
//     Debug.Log(gameObject.name + " is rescuing the survivor.");
// }

// // Clear Obstacle
// public void ClearObstacle()
// {
//     Debug.Log(gameObject.name + " is clearing the obstacle.");
// }

// // Return to Base
// public void ReturnToBase(Vector3 baseLocation)
// {
//     MoveCommand(baseLocation);
// }
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
        manager.ReceiveRobotPosition(
            gameObject.name,
            transform.position);
    }
}





//     // Instead of having the robot know about BasicAI, you can make the robot completely independent.
// public class SimpleMoving : MonoBehaviour
// {
//     private NavMeshAgent agent;

//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//     }

//     public void MoveCommand(Vector3 target)
//     {
//         agent.SetDestination(target);
//     }

//     public Vector3 GetPosition()
//     {
//         return transform.position;
//     }

//     public bool HasReachedDestination()
//     {
//         return !agent.pathPending &&
//                agent.remainingDistance <= agent.stoppingDistance;
//     }
// }