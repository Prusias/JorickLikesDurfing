using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interctable : MonoBehaviour {
	// Start is called before the first frame update

	public bool Working = false;
	public bool OnFire = false;

	public void OnTriggerEnter2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
	}
	public void OnTriggerExit2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
	}

	public virtual void Interract(Tool.ToolType heldTool, float deltaTime) {
	}
}