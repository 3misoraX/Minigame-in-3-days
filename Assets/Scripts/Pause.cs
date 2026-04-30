using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool paused = false;
    public InputActionReference pauseInput;
    public Player player;
    
    // Update is called once per frame
    void Update()
    {
        if (pauseInput.action.triggered == true)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        PauseMenu.SetActive(true);
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    //Resume continues runtime
    public void Resume()
    {
        PauseMenu.SetActive(false);
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
