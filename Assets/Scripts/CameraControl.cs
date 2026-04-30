using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private void Awake()
    {
        //Hide the cursor in game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Suscription to Game Manager
        GameManager.OnGameStateChange += GameManagerOnOnGameStateChange;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange += GameManagerOnOnGameStateChange;
    }

    private void GameManagerOnOnGameStateChange(GameManager.GameState state)
    {
        //if the state is changed, the cursos will appear or disappear
        if(GameManager.Instance.State == GameManager.GameState.Gameplay)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
