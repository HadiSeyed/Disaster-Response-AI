using UnityEngine;

public class Survivor : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

{
    public bool rescued = false;

    public void Rescue()
    {
        if (rescued)
            return;

        rescued = true;

        Debug.Log(gameObject.name + " has been rescued!");
    }
}