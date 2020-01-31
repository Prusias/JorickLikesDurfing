using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
	private bool IsWorking = false;
	private bool IsOnFire = false;

	public float Health = 100f;

	private bool interacting;

	public void Interract(Tool.ToolType heldTool, float deltaTime) {
		if (heldTool == Tool.ToolType.FireExtinguisher) {
			Health += 50f * deltaTime;
		}

	}

	public void OnTriggerEnter2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
	}

	public void OnTriggerExit2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
	}

	public bool Working() {
		return IsWorking;
	}
	public bool OnFire() {
		return IsOnFire;
	}
	public void SetWorking(bool isWorking) {
		IsWorking = isWorking;
	}
	public void SetOnFire(bool isOnFire) {
		IsOnFire = isOnFire;
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
