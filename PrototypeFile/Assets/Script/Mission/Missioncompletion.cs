using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Mission mission1; // Define this in the inspector or through code
    private bool mission1Completed = false; // To track if the mission is already completed

    void Update()
    {
        if (!mission1Completed) // Check if the mission is not already completed
        {
            Inventory playerInventory = FindObjectOfType<Inventory>();
            if (playerInventory.CheckMissionCompletion(mission1))
            {
                Debug.Log("Mission 1 Completed");
                mission1Completed = true;
                // Add any other mission completion logic here
            }
        }
    }
}
