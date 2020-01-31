using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
	// Start is called before the first frame update

	bool Working();
	void SetWorking(bool isWorking);
	bool OnFire();
	void SetOnFire(bool isOnFire);

	void OnTriggerEnter2D(Collider2D collision); //{
														 //collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
														 //}
	void OnTriggerExit2D(Collider2D collision); // {
												//collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
												//}

	void Interract(Tool.ToolType heldTool);
}
