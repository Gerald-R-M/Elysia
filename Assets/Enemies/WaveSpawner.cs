using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
	/// <summary>
	/// Enemies to Spawn
	/// </summary>
	[SerializeField] private GameObject meleeEnemy;
	//[SerializeField] private GameObject rangedEnemy;
	
	/// <summary>
	/// Locations to spawn
	/// </summary>
	[SerializeField] private GameObject[] meleeSpawns;
	//[SerializeField] private GameObject[] rangedSpawns;
	
	
	
	/// <summary>
	/// Spawning variables
	/// </summary>
	private Vector3 _spawnerCoords;
	
	/// <summary>
	/// Wave Tracking Variables
	/// </summary>
	private int _waveCounter = 0;
	private bool waveState;
	

	/// <summary>
	/// Randomizing Variables
	/// </summary>
	[SerializeField] private float rangeX; // how far on the x axis should be the max randomization for enemy spawns
	[SerializeField] private float rangeZ; // how far on the z axis should be the max randomization for enemy spawns
	public void SpawnWave()
	{
		foreach (GameObject location in meleeSpawns)
		{
			_spawnerCoords = location.transform.position;
			if (_waveCounter > 0)
			{
				for (int i = 0; i <= _waveCounter; i++)
				{
					_spawnerCoords.x = Random.Range((_spawnerCoords.x + 5), rangeX);
					_spawnerCoords.z = Random.Range((_spawnerCoords.z + 5), rangeZ);
					Instantiate(meleeEnemy, _spawnerCoords, quaternion.identity);
				}
			}
			else
			{
				Instantiate(meleeEnemy, _spawnerCoords, quaternion.identity);
			}

		}


		_waveCounter++;
		waveState = true;
	}

	public bool IsWaveActive()
	{
		return waveState;
	}
}
