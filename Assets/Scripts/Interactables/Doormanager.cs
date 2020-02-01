using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doormanager : Interctable
{
	public bool Tutorial = true;
	public float health = 2f;

	public float repairSpeed = 50f;

	public float fireState = 0f;
	public float maxFireState = 30f;
	public float fireSpeed = 1f;
	public float exstinguishSpeed = 10f;

	public GameObject healthBar;
	public GameObject Fire;

	private void Start() {
		fireState = 1f;
		OnFire = true;
	}

	public override void Interract(Tool.ToolType heldTool, float deltaTime) {
		if (Tutorial) {
			
			
		}
		if (heldTool == Tool.ToolType.Wrench) {
			health += repairSpeed * Time.deltaTime;

			if (health > 200f) {
				Working = true;
				health = 200f;
				healthBar.GetComponent<SpriteRenderer>().color = Color.green;
			}

			Vector2 scale = healthBar.transform.localScale;
			scale.x = health / 100;
			healthBar.transform.localScale = scale;
		}
		else if (heldTool == Tool.ToolType.FireExtinguisher) {
			fireState -= exstinguishSpeed * Time.deltaTime;

			if (fireState < 0f) {
				fireState = 0f;
				OnFire = false;
				Fire.SetActive(false);
			}
		}
	}

	public void FixedUpdate() {
		if (fireState > 0f) {
			fireState += Time.deltaTime * fireSpeed;
		}
		if (fireState > maxFireState) {
			Working = false;
			fireState = maxFireState;
		}
	}
}
