using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private int maxHealth = 3;
	[SerializeField] private int playerHealth;
	[SerializeField] private GameObject gameOverMenu;
	public Renderer playerRenderer;

	private float hitTime = 1;
	private float hitTimer = 0;
	private bool canHit = true;
	private bool isColliding; 


	void Start()
	{
		playerHealth = maxHealth;
		playerRenderer.material.color = new Color(0f, 0f, 1f, 0f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isColliding)
		{
			return;
		}
		isColliding = true;

		if (other.gameObject.CompareTag("Projectile"))
		{
			TakeDamage(1);
		}

		if (other.gameObject.CompareTag("Water"))
		{
			TakeDamage(3);
		}

		if (other.gameObject.CompareTag("Pickup") && playerHealth < 3)
		{
			playerHealth = playerHealth + 1;
		}
	}

	void Update()
	{
		isColliding = false;
		hitTimer += Time.deltaTime;
		if (hitTimer > hitTime)
		{
			canHit = true;
		}

		if (playerHealth == 3)
		{
			playerRenderer.material.color = new Color(0f, 0f, 1f, 0f);
		}

		if (playerHealth == 2)
		{
			playerRenderer.material.color = new Color(1f, 0.92f, 0.016f, 1f);
		}

		if (playerHealth == 1)
		{
			playerRenderer.material.color = new Color(1f, 0f, 0f, 0f);
		}
	}

	public void TakeDamage(int damage)
	{
		if (!canHit)
		{
			return;
		}
		else
		{
			playerHealth = playerHealth - damage;
			if (playerHealth <= 0)
			{
				gameObject.SetActive(false);
				gameOverMenu.SetActive(true);
				Cursor.visible = true;
			}

			hitTimer = 0;
		}
	}
}
