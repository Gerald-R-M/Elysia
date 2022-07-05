using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWaveInput : MonoBehaviour
{
    /// <summary>
    /// Unity Input System Variables
    /// </summary>
    private PlayerControls _input;
    private InputAction _spawn;
    /// <summary>
    /// Wave Spawner Reference Variable(s)
    /// </summary>
    [SerializeField] private WaveSpawner _spawnerRef;
    private void Awake()
    {
        _input = new PlayerControls();
        
    }
    private void OnEnable()
    {
        _spawn = _input.Player.SpawnWave;
        _spawn.Enable();
    }
    private void OnDisable()
    {
        _spawn.Disable();
        _input.Disable();
    }
    


    // Update is called once per frame
    void Update()
    {
        if (_spawn.IsPressed() && !_spawnerRef.IsWaveActive())
        {
            _spawnerRef.SpawnWave();
        }
    }
}
