using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
	private bool IsWorking = false;
	private bool IsOnFire = false;


	public void Interract(Tool.ToolType heldTool) {
		Debug.Log("Interracted using: " + heldTool);
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
        
    }

	
}
