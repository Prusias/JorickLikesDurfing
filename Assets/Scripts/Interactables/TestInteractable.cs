using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interctable
{
	public float Health = 100f;

	private bool interacting;

	public override void Interract(Tool.ToolType heldTool, float deltaTime) {
		if (heldTool == Tool.ToolType.FireExtinguisher) {
			Health += 50f * deltaTime;
		}

	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		Health -= 10f * Time.deltaTime;

    }

	
}
