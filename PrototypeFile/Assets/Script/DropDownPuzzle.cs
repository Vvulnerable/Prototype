using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Dropdown[] questions; // Assign these in the inspector
    [SerializeField] private Button finishButton;
    [SerializeField] private string nextSceneName; // The name of the next scene to load

    // Serialize this field to set correct answers for each question in the inspector
    [SerializeField] private int[] correctAnswers;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        finishButton.onClick.AddListener(CheckAnswers);
    }

    private void CheckAnswers()
    {
        bool allCorrect = true;
        for (int i = 0; i < questions.Length; i++)
        {
            if (questions[i].value != correctAnswers[i])
            {
                allCorrect = false;
                break; // Stop checking further if any answer is wrong
            }
        }

        if (allCorrect)
        {
            Debug.Log("Correct");
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Incorrect. Try again.");
            // Optionally, reload the current scene or provide feedback
        }
    }
}
