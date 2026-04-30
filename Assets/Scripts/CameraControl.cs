using JetBrains.Annotations;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private void Awake()
    {
        //Hide the cursor in game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
