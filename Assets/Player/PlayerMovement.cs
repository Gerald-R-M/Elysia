using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// Videos used for this script:
///     Brackeys third person movement: https://www.youtube.com/watch?v=4HpC--2iowE
///     Bmo Unity's New Input System: https://www.youtube.com/watch?v=HmXU4dZbaMw
///     Shoutout to Andromeda Ball Movement Code for helping me realize to add the composite binding
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    /// <summary>
    /// Inspector Variables
    /// </summary>
    [SerializeField] private float playerSpeed = 6f;
    [SerializeField] private float playerRotationSmoothing = 0.1f;
    [SerializeField] private Transform camera;

    /// <summary>
    /// Unity Input System Variables
    /// </summary>
    private PlayerControls _input;
    private InputAction _movement;
    
    /// <summary>
    /// Player Movement Variables
    /// </summary>
    private Vector2 _moveInput;
    private Vector3 _moveDirection;
    private Vector3 _moveCameraDirection; //Used to calculate player movement in relation to camera

    /// <summary>
    /// Player Rotation Variables
    /// </summary>
    private float _targetAngle;
    private float _smoothAngle;
    private float _turnSmoothVelocity; //Used in smoothing player turning formula
    
    // Update is called once per frame
    private void Awake()
    {
        _input = new PlayerControls();
        _controller = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        _movement = _input.Player.Movement;
        _movement.Enable();
    }
    private void OnDisable()
    {
        _movement.Disable();
        _input.Disable();
    }

    void Update()
    {
        if (_movement.IsPressed())
        {
            _moveInput = _movement.ReadValue<Vector2>();
            Rotation(_moveInput);
            Move(_moveInput);
        }
        
    }
    private void Move(Vector2 input)
    {
        _moveDirection = new Vector3 (input.x, 0, input.y).normalized;
        _controller.Move(_moveCameraDirection * playerSpeed * Time.deltaTime);
    }

    private void Rotation(Vector2 input)
    {
        _targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
        _smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity,
            playerRotationSmoothing);
        _moveCameraDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
        transform.rotation = Quaternion.Euler(0f, _smoothAngle, 0f);
    }
}
