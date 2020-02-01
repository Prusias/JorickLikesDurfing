using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : Interctable
{
	public bool Tutorial = true;
	public float health = 2f;
	public float repairSpeed = 50f;

	public GameObject healthBar;

	public override void Interract(Tool.ToolType heldTool, float deltaTime) {
		if (Tutorial) {
			if (heldTool == Tool.ToolType.ElectricityKit) {
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
			
		}
	}
}
