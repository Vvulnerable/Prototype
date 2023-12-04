using UnityEngine;

public class ClueObject : MonoBehaviour, IInteractable, IClueProvider
{
    [SerializeField] private Clue clueDetails; // Assign this in the inspector
    public string InteractionPrompt => "Pick up Clue"; // Example prompt

    // Interact method from IInteractable
    public bool Interact(Interactor interactor)
    {
        // Add the clue to the player's inventory and disable the object
        if (interactor != null)
        {
            Inventory playerInventory = interactor.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                playerInventory.AddClue(GetClue());
                Debug.Log(clueDetails.clueID + " collected"); // Log message to the console
                gameObject.SetActive(false); // Hide the clue object
                return true;
            }
        }
        return false;
    }

    // GetClue method from IClueProvider
    public Clue GetClue()
    {
        return clueDetails;
    }
}
