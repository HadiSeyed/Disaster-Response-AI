//   // First script:

// using NUnit.Framework;
// using UnityEngine;
// using System.Collections.Generic;
// using System;

// public class BasicAI : MonoBehaviour
// {
//     List<GameObject> robots;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         // Get some references to all of our "robots"
//         robots.Add(GameObject.Find("Robot1"));
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         robots[0].GetComponent<SimpleMoving>().ReceiveMessage("hi!");
//     }
// }



    // Second script:

using System;
using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class BasicAI : MonoBehaviour
{
    private List<GameObject> robots = new List<GameObject>();

    void Start()
    {
        robots.Add(GameObject.Find("Robot 1"));
        robots.Add(GameObject.Find("Robot 2"));
        // robots.Add(GameObject.Find("Robot 3"));
    }

// Move Robot
    public void SendRobotToLocation(Vector3 target)
{
    if (robots.Count == 0)
    {
        Debug.LogWarning("No robots available!");
        return;
    }

    robots[0].GetComponent<SimpleMoving>().MoveCommand(target);

    // robots[0].GetComponent<SimpleMoving>().MoveCommand(location);
    // Debug.Log("AI: Moving Robot 1");
}

// Search Area
    public void StartSearch()
{
    Debug.Log("AI: Search Area");

    Vector3 searchLocation = new Vector3(12, 0, 5);

    robots[0].GetComponent<SimpleMoving>()
             .MoveCommand(searchLocation);
}

// Rescue Survivor
    public void StartRescue()
{
    Debug.Log("AI: Rescue Survivor");

    Vector3 survivorLocation = new Vector3(20,0,-10);

    robots[0].GetComponent<SimpleMoving>()
             .MoveCommand(survivorLocation);
}

// Return to Base
    private Vector3 baseLocation = new Vector3(0,0,0);

    public void ReturnRobotToBase()
{
    Debug.Log("AI: Return to Base");

    robots[0].GetComponent<SimpleMoving>()
             .MoveCommand(baseLocation);
}

// Mark Survivor
    private bool placingSurvivor = false;

    public void EnableMarkSurvivorMode()
{
    placingSurvivor = true;

    Debug.Log("Click on the ground to place a survivor.");
}

// Clear Obstacle
    public void ClearSelectedObstacle()
{
    Debug.Log("AI: Clearing Obstacle");

    Vector3 obstacleLocation = new Vector3(-5,0,15);

    robots[0].GetComponent<SimpleMoving>()
             .MoveCommand(obstacleLocation);
}

    public void ReceiveRobotReport(string robotName,
                                   string report)
    {
        Debug.Log(robotName + " reports: " + report);
    }

    public void ReceiveRobotPosition(string robotName,
                                     Vector3 position)
    {
        Debug.Log(robotName +
                  " position: " +
                  position);
    }

    void Update()
    {
        foreach(GameObject robot in robots)
        {
            robot.GetComponent<SimpleMoving>()
                 .ReportPosition();
                 
            robots[0].GetComponent<SimpleMoving>()
            .MoveCommand(new Vector3(7,0,-9));
        }

        // if(placingSurvivor && Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //     RaycastHit hit;

        //     if(Physics.Raycast(ray, out hit))
        //     {
        //         Debug.Log("Survivor marked at " + hit.point);

        //         placingSurvivor = false;
        //     }
        // }
    }
}