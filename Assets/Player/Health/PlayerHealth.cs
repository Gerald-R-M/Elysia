using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	/// <summary>
	/// Inspector Variables
	/// </summary>
	[SerializeField]
	private float maxHealth = 100f;
	[SerializeField]
	private Image healthBarRef;
	/// <summary>
	/// Slider Variables
	/// </summary>
	public float _currentHealth; // TODO make private after testing player damage
	
    // Start is called before the first frame update
    void Start()
	{
		_currentHealth = maxHealth;
	}

    // Update is called once per frame
    void Update()
	{
		healthBarRef.fillAmount = _currentHealth / maxHealth;
		if (_currentHealth <= 0)
		{
			GameOver();
		}
	}

	public void DamagePlayer(float damageTaken)
	{
		_currentHealth -= damageTaken;
	}

	private void GameOver()
	{
		Debug.Log("Player has died!");
		//TODO death logic
	}
}
