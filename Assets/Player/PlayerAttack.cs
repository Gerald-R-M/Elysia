using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerControls _input;
    private InputAction _attack;

    // Start is called before the first frame update
    void Awake()
    {
        _input = new PlayerControls();
    }
    private void OnEnable()
    {
        _attack = _input.Player.Attack;
        _attack.Enable();
        _attack.performed += MainAttack;
    }
    private void OnDisable()
    {
        _input.Disable();
        _attack.Disable();
    }
    private void MainAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Player attacked!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
