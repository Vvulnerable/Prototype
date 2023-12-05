using System.Linq;
using System.Reflection;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public Mission mission; // Define this in the inspector or through code
    private bool missionCompleted = false; // To track if the mission is already completed

    void Update()
    {
        if (!missionCompleted)
        {
            Inventory playerInventory = FindObjectOfType<Inventory>();
            if (playerInventory != null && playerInventory.CheckMissionCompletion(mission))
            {
                missionCompleted = true;

                string combinedDescriptions = string.Join(" ", mission.requiredClues.Select(clueID => playerInventory.GetClueById(clueID)?.description));

                // Log the completion message to the console
                Debug.Log($"{mission.missionName} completed: {combinedDescriptions}");
            }
        }
    }
}
