﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable 
{
	// Start is called before the first frame update


	 void OnTriggerEnter2D(Collider2D collision); //{
														 //collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
														 //}
	void OnTriggerExit2D(Collider2D collision); // {
		//collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
	//}
}
