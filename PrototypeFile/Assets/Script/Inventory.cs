using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Clue> clues = new List<Clue>();

    public void AddClue(Clue clue)
    {
        clues.Add(clue);
        // Update the UI here if needed
    }

    public bool HasAllClues(int requiredClues)
    {
        return clues.Count >= requiredClues;
    }

    // You can add methods to display the inventory UI and other functionalities
}
