using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Tool
{
	public new ToolType toolType = ToolType.Flashlight;
	public Player player;

	public override GameObject PickUp() {
		gameObject.SetActive(false);
		player.hasFlashlight = true;
		return null;
	}

	public override void Drop(Vector2 position, Vector2 direction, float throwingTime) {
		return;
	}




}
