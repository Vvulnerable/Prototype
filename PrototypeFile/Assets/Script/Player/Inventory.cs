using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Clue> clues = new List<Clue>();

    public void AddClue(Clue clue)
    {
        if (!clues.Any(c => c.clueID == clue.clueID))
        {
            clues.Add(clue); // Avoid adding duplicates
            UpdateUI(); // Update UI or game state as needed
        }
    }

    public bool CheckMissionCompletion(Mission mission)
    {
        return mission.IsCompleted(clues);
    }

    public Clue GetClueById(string clueID)
    {
        return clues.FirstOrDefault(clue => clue.clueID == clueID);
    }

    public bool HasClue(string clueID)
    {
        return clues.Any(clue => clue.clueID == clueID);
    }

    private void UpdateUI()
    {
        // Implement UI update logic here
        // For example, refreshing the inventory display
    }

    // Debugging method to display all clues in the inventory
    public void DisplayAllClues()
    {
        foreach (var clue in clues)
        {
            Debug.Log($"Clue ID: {clue.clueID}, Description: {clue.description}");
        }
    }
}
