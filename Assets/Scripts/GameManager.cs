using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    //Game Manager references
    public static GameManager Instance;

    public GameState State;
    public static event Action<GameState> OnGameStateChange;

    //Pause references
    public GameObject PauseMenu;
    public bool paused = false;
    public InputActionReference pauseInput;


    public enum GameState
    {
        MainMenu,
        Gameplay,
        Pause,
        Gameover
    }

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        //State changes
        switch (State)
        {
            case GameState.MainMenu:
                //Go to main menu
                break;
            case GameState.Gameplay:
                //Go to gameplay
                break;
            case GameState.Pause:
                //Detects input to pause game
                if (pauseInput.action.triggered == true)
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
                break;
            case GameState.Gameover:
                //Activate Game over
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChange?.Invoke(newState);
    }

    //Pause stops the game
    public void Pause()
    {
        PauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    //Resume continues runtime
    public void Resume()
    {
        PauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
}
