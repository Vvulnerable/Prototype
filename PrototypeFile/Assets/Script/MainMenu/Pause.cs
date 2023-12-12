using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    public bool pause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) pause = true;
        if (pause) Time.timeScale = 0f;
        if (pause) pausemenu.SetActive(true);
        if (pause) Cursor.lockState = CursorLockMode.None;
        if (pause) Cursor.visible = true;
    }

    public void Resume()
    {
        pause = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
