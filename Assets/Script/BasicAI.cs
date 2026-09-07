using System;
using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class BasicAI : MonoBehaviour
{
    private List<GameObject> robots = new List<GameObject>();
    private List<GameObject> firefighters = new List<GameObject>();
    private List<GameObject> drones = new List<GameObject>();
    private List<GameObject> survivors = new List<GameObject>();

    private bool placingSurvivor = false;

    private Vector3 baseLocation = new Vector3(0, 0, 0);

    void Start()
    {
        // Find robots
        robots.Add(GameObject.Find("Robot 1"));
        robots.Add(GameObject.Find("Robot 2"));

        // Find firefighters
        firefighters.Add(GameObject.Find("Firefighter1"));
        firefighters.Add(GameObject.Find("Firefighter2"));

        // Find drones
        drones.Add(GameObject.Find("Drone1"));
        drones.Add(GameObject.Find("Drone2"));

        // Find survivors
        survivors.Add(GameObject.Find("Survivor1"));
        survivors.Add(GameObject.Find("Survivor2"));

        Debug.Log("AI Manager started.");
        Debug.Log("Robots: " + robots.Count);
        Debug.Log("Firefighters: " + firefighters.Count);
        Debug.Log("Drones: " + drones.Count);
        Debug.Log("Survivors: " + survivors.Count);
    }

    // Make the AI choose between the two firefighters (Find the firefighter closest to the target)
    private GameObject FindClosestFirefighter(Vector3 target)
    {
        GameObject closestFirefighter = null;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject firefighter in firefighters)
        {
            if (firefighter == null)
                continue;
            
            float distance = Vector3.Distance(
                firefighter.transform.position,
                target
            );

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestFirefighter = firefighter;
            }
        }

        return closestFirefighter;
    }

    // Rescue Survivor: AI decides which firefighter should rescue the survivor
    public void StartRescue()
    {
        if (survivors.Count == 0)
        {
            Debug.Log("AI: No survivors found.");
            return;
        }

        GameObject survivor = survivors[0];
        if (survivor == null)
        {
            Debug.Log("AI: Survivor1 could not be found.");
            return;
        }

        Vector3 survivorLocation = survivor.transform.position;

        // Find the closest firefighter (The AI checks both firefighters then sends whichever firefighter is closer)
        GameObject closestFirefighter = FindClosestFirefighter(survivorLocation);

        if (closestFirefighter == null)
        {
            Debug.Log("AI: No firefighters available.");
            return;
        }

        Debug.Log(
            "AI: Sending " + closestFirefighter.name +
            " to " + survivor.name
        );

        // // Sends whichever firefighter is closer
        // closestRobot.GetComponent<SimpleMoving>()
        //             .MoveCommand(survivorLocation);
        SimpleMoving firefighterMovement =
            closestFirefighter.GetComponent<SimpleMoving>();

        if (firefighterMovement == null)
        {
            Debug.LogWarning(
                closestFirefighter.name +
                " does not have SimpleMoving."
            );

            return;
        }

        firefighterMovement.MoveCommand(survivorLocation);
    }


    // // Rescue Survivor: Make the AI rescue a survivor (robots[0]: That always means Firefighter1)
    // public void StartRescue()
    // {
    // if (survivors.Count == 0)
    // {
    //     Debug.Log("AI: No survivors found.");
    //     return;
    // }

    // GameObject survivor = survivors[0];

    // Vector3 survivorLocation = survivor.transform.position;

    // Debug.Log("AI: Sending Firefighter1 to Survivor1.");

    // robots[0].GetComponent<SimpleMoving>()
    //          .MoveCommand(survivorLocation);
    // }

// Move Robot
    public void SendRobotToLocation(Vector3 target)
    {
    if (robots.Count == 0)
    {
        Debug.LogWarning("No robots available!");
        return;
    }

    // robots[0].GetComponent<SimpleMoving>().MoveCommand(target);

    // // robots[0].GetComponent<SimpleMoving>().MoveCommand(location);
    // // Debug.Log("AI: Moving Robot 1");
    if (robots[0] == null)
        {
            Debug.LogWarning("Robot 1 could not be found!");
            return;
        }

        SimpleMoving movement =
            robots[0].GetComponent<SimpleMoving>();

        if (movement != null)
        {
            movement.MoveCommand(target);
        }
    }

// Search Area
    public void StartSearch()
    {
        Debug.Log("AI: Search Area");

        Vector3 searchLocation = new Vector3(12, 0, 5);

        // robots[0].GetComponent<SimpleMoving>()
        //          .MoveCommand(searchLocation);
        SendRobotToLocation(searchLocation);
    }

// // Rescue Survivor
//     public void StartRescue()
//     {
//     Debug.Log("AI: Rescue Survivor");

//     Vector3 survivorLocation = new Vector3(20,0,-10);

//     robots[0].GetComponent<SimpleMoving>()
//              .MoveCommand(survivorLocation);
//     }

// Return to Base
    // private Vector3 baseLocation = new Vector3(0,0,0);

    public void ReturnRobotToBase()
    {
    Debug.Log("AI: Return to Base");

    // robots[0].GetComponent<SimpleMoving>()
    //          .MoveCommand(baseLocation);
    SendRobotToLocation(baseLocation);
    }

// Mark Survivor
    // private bool placingSurvivor = false;

    public void EnableMarkSurvivorMode()
    {
    placingSurvivor = true;

    Debug.Log("AI: Click on the ground to place a survivor.");
    }

// Clear Obstacle
    public void ClearSelectedObstacle()
    {
    Debug.Log("AI: Clearing Obstacle");

    Vector3 obstacleLocation = new Vector3(-5,0,15);

    // robots[0].GetComponent<SimpleMoving>()
    //          .MoveCommand(obstacleLocation);
    SendRobotToLocation(obstacleLocation);
    }

    // Robot Report
    public void ReceiveRobotReport(string robotName,
                                   string report)
    {
        Debug.Log(robotName + " reports: " + report);
    }

    // Robot Position
    public void ReceiveRobotPosition(string robotName,
                                     Vector3 position)
    {
        Debug.Log(robotName +
                  " position: " +
                  position);
    }

    // MARK SURVIVOR WITH MOUSE
    void Update()
    {
        foreach(GameObject robot in robots)
        {
            robot.GetComponent<SimpleMoving>()
                 .ReportPosition();
                 
            // robots[0].GetComponent<SimpleMoving>()
            // .MoveCommand(new Vector3(7,0,-9));
        }
    }
}