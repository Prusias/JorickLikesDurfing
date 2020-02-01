using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour, IInteractable
{
	public bool Tutorial = true;

	public bool isWorking = false;


	public void Interract(Tool.ToolType heldTool, float deltaTime) {
		if (Tutorial) {
			if (!isWorking) {
				isWorking = true;



			}
		}
	}

	public bool OnFire() {
		throw new System.NotImplementedException();
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
	}

	public void OnTriggerExit2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
	}

	public void SetOnFire(bool isOnFire) {
		throw new System.NotImplementedException();
	}

	public void SetWorking(bool isWorking) {
		isWorking = true;
	}

	public bool Working() {
		return isWorking;
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
