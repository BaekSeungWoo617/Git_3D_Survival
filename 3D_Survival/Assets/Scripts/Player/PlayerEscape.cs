using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerEscape : MonoBehaviour
{
    public Action escape;
    public bool escapeCanLook = true;
    private PlayerController playerController;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponent<PlayerController>();
    }
    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            escape?.Invoke();
            ToggleCursor();
        }
    }
    public void SetOnEscape(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            escape?.Invoke();
            ToggleCursor();
        }
    }
    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        escapeCanLook = !toggle;
        playerController.canLook = escapeCanLook;
    }
}
