using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
	public Player player;

	private void Start() {
		this.toolType = ToolType.Flashlight;
	}

	public override GameObject PickUp() {
		gameObject.SetActive(false);
		player.hasFlashlight = true;
		return null;
	}

	public override void Drop(Vector2 position, Vector2 direction, float throwingTime) {
		return;
	}




}
