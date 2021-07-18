using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInput input;
    public InputAction actionMove;
    public InputAction actionInteract;
    public InputAction actionAttack1;
    public InputAction actionAttack2;
    public InputAction actionDefend;
    public InputAction actionCancel;

    public InputAction actionEscape;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        actionMove = input.actions["Move"];
        actionEscape = input.actions["Escape"];
        actionInteract = input.actions["Interact"];
        actionAttack1 = input.actions["Attack1"];
        actionAttack2 = input.actions["Attack2"];
        actionDefend = input.actions["Defend"];
        actionCancel = input.actions["Cancel"];

        Debug.Log(input.currentActionMap);
        Debug.Log(input.currentControlScheme);
    }
}
