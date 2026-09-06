using UnityEngine;

public class UIManager : MonoBehaviour
{
    private BasicAI aiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aiManager = FindFirstObjectByType<BasicAI>();   
    }

    public void MoveRobot()
    {
        aiManager.SendRobotToLocation(new Vector3(7, 0, -9));
    }

    public void SearchArea()
    {
        aiManager.StartSearch();
    }

    public void RescueSurvivor()
    {
        aiManager.StartRescue();
    }

    public void ReturnToBase()
    {
        aiManager.ReturnRobotToBase();
    }

    public void MarkSurvivor()
    {
        aiManager.EnableMarkSurvivorMode();
    }

    public void ClearObstacle()
    {
        aiManager.ClearSelectedObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}





// using UnityEngine;

// public class UIManager : MonoBehaviour
// {
//     public BasicAI aiManager;

//     public void MoveRobot()
//     {
//         Debug.Log("Move button pressed!");

//         aiManager.SendRobotToLocation(new Vector3(7, 0, -9));
//     }

//     public void SearchArea()
//     {
//         Debug.Log("Search button pressed!");
//     }

//     public void MarkSurvivor()
//     {
//         Debug.Log("Mark Survivor button pressed!");
//     }
// }