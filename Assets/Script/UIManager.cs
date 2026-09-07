using UnityEngine;

public class UIManager : MonoBehaviour
{
    private BasicAI AIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AIManager = FindFirstObjectByType<BasicAI>();   
    }

    public void MoveRobot()
    {
        AIManager.SendRobotToLocation(new Vector3(7, 0, -9));
    }

    public void SearchArea()
    {
        AIManager.StartSearch();
    }

    public void RescueSurvivor()
    {
        AIManager.StartRescue();
    }

    public void ReturnToBase()
    {
        AIManager.ReturnRobotToBase();
    }

    public void MarkSurvivor()
    {
        AIManager.EnableMarkSurvivorMode();
    }

    public void ClearObstacle()
    {
        AIManager.ClearSelectedObstacle();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}