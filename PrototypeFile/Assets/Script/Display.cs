using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugDisplay : MonoBehaviour
{
    public Text legacyText; // Reference to the Legacy Text component
    public float displayDuration = 2f; // Duration in seconds to display the text
    private bool canClearText = false; // Flag to check if text can be cleared

    void Start()
    {
        if (legacyText == null)
        {
            Debug.LogError("Legacy Text component is not assigned.");
            return;
        }

        legacyText.text = "";
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Clear existing text and reset the flag
        legacyText.text = "";
        canClearText = false;

        // Display new text
        legacyText.text = logString + "\n";

        // Stop any existing coroutine and start a new one for the new text
        StopAllCoroutines();
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        canClearText = true; // After 2 seconds, allow text to be cleared
    }

    void Update()
    {
        if (canClearText && Input.GetKeyDown(KeyCode.E))
        {
            legacyText.text = ""; // Clear the text if 'E' is pressed after 2 seconds
            canClearText = false; // Reset the flag
        }
    }
}
