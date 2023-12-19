using UnityEngine;
using UnityEngine.UI;  // Required for UI elements like InputField

public class InputFieldController : MonoBehaviour
{
    public InputField inputField;  // Assign this in the inspector
    private bool isInputFieldActive = false;

    void Start()
    {
        // Hide the input field at the start
        inputField.gameObject.SetActive(false);
        
    }

    void Update()
    {
        // Check for the Tab key press
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInputField();
      
        }
    }

    private void ToggleInputField()
    {
        isInputFieldActive = !isInputFieldActive;  // Toggle the state
        inputField.gameObject.SetActive(isInputFieldActive);

        if (isInputFieldActive)
        {
            // Pause the game
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;   
            Cursor.visible = false; 
        }
    }
}
