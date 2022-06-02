using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float playerSpeed = 6f;
    
    private PlayerControls _input;
    // Update is called once per frame
    private void Awake()
    {
        _input = new PlayerControls();
        _input.Player.Attack.performed += test => MainAttack();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    void MainAttack()
    {
        Debug.Log("Player attacked!");
    }

    void Update()
    {
        
    }
}
