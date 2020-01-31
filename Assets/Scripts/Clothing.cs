using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
	public enum ClothingType {
		Default,
		SpaceSuit,
		FireProofSuit,
		WeldingMask
	}

	public float movementModifier;
	public ClothingType clothingType;

	public GameObject Pickup() {
		gameObject.SetActive(false);
		return gameObject;
	}

	public void Drop(Vector2 position) {
		gameObject.SetActive(true);
		gameObject.transform.position = position;
	}


}

