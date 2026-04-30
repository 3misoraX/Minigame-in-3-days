using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pausa : MonoBehaviour
{
    public GameObject menu;
    public bool paused = false;
    public InputActionReference input;
    
    // Update is called once per frame
    void Update()
    {
        if(input.action.triggered == true)
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        menu.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        menu.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
}
