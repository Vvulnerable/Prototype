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
            // Update UI or game state as needed
        }
    }

    public bool CheckMissionCompletion(Mission mission)
    {
        return mission.IsCompleted(clues);
    }
}
