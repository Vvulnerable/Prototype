using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugDisplay : MonoBehaviour
{
    public Text legacyText; // Reference to the Legacy Text component
    public float displayDuration = 5f; // Duration in seconds to display the text

    void Start()
    {
        // Make sure you've assigned the Legacy Text component in the Unity Inspector
        if (legacyText == null)
        {
            Debug.LogError("Legacy Text component is not assigned.");
            return;
        }

        // Clear the initial text in the Legacy Text component
        legacyText.text = "";

        // Register for log message events
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        // Unregister log message events when the GameObject is destroyed
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Append the log message to the existing text in the Legacy Text component
        legacyText.text += logString + "\n";

        // Start a coroutine to hide the text after the specified duration
        StartCoroutine(HideTextAfterDelay());
    }

    IEnumerator HideTextAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Clear the text in the Legacy Text component
        legacyText.text = "";
    }
}
