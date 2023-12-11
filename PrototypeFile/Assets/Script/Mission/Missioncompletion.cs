using System.Linq;
using UnityEngine;

public class MissionManager : MonoBehaviour, IInteractable
{
    public Mission mission; // Define this in the inspector or through code
    private bool missionCompleted = false; // To track if the mission is already completed

    public string InteractionPrompt => "Press E to check Mission Status";

    public bool Interact(Interactor interactor)
    {
        if (!missionCompleted)
        {
            Inventory playerInventory = FindObjectOfType<Inventory>();
            if (playerInventory != null)
            {
                if (playerInventory.CheckMissionCompletion(mission))
                {
                    missionCompleted = true;
                    Debug.Log($"Mission Completed: {mission.missionName}. {mission.missionDescription}");
                }
                else
                {
                    DisplayMissingClues(playerInventory);
                }
            }
        }
        else
        {
            Debug.Log($"Mission already completed: {mission.missionName}");
        }

        return true;
    }

    private void DisplayMissingClues(Inventory playerInventory)
    {
        string missingClues = string.Join(", ", mission.requiredClues.Where(clueID => !playerInventory.HasClue(clueID)));
        Debug.Log($"Mission: {mission.missionName}. Missing Clues: {missingClues}");
    }
}
