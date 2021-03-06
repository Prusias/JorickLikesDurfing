﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public GameObject[] tools;
	public GameObject closestTool;
	public GameObject heldTool = null;
	public GameObject wornClothing;
	public float lowestDistance = Mathf.Infinity;
	public float pickupDistance = 0.5f;
	public GameObject interactableObject;
	public GameObject nearbyClothing;
	public float throwingTime = .25f;

	public GameObject alert;
	public GameObject camera;

	// Movement
	public Rigidbody2D rb;
	public float movementSpeed = 5f;
	public Vector2 movement;

	public SpriteRenderer tooltip_E;
	public SpriteRenderer tooltip_Ctrl;

	public bool hasFlashlight;


	// Start is called before the first frame update
	void Start()
    {
		tools = GameObject.FindGameObjectsWithTag("Tool");


		rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
			if (nearbyClothing != null) {
				wornClothing.GetComponent<Clothing>().Drop(gameObject.transform.position);
				wornClothing = nearbyClothing.GetComponent<Clothing>().Pickup();
			} else {
				if (heldTool != null) {
					heldTool.GetComponent<Tool>().Drop(gameObject.transform.position, movement, throwingTime);
					heldTool = null;
				} else {
					if (lowestDistance < pickupDistance) {
						heldTool = closestTool.GetComponent<Tool>().PickUp();



					}
				}
			}
			
		}
		if (Input.GetKey(KeyCode.LeftControl)) {
			if(interactableObject != null) {
				if(heldTool != null) {
					interactableObject.GetComponent<Interctable>().Interract(heldTool.GetComponent<Tool>().toolType, Time.deltaTime);
				} else {
					interactableObject.GetComponent<Interctable>().Interract(Tool.ToolType.None, Time.deltaTime);
				}
			}
		}


		movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
		movement.y = Input.GetAxisRaw("Vertical"); // -1 is down

	}

	void FixedUpdate() {
		
		foreach (GameObject tool in tools) {
			if (closestTool != null) {
				float distanceToClosest = Vector2.Distance(gameObject.transform.position, closestTool.transform.position);
				lowestDistance = distanceToClosest;
			}

			float distance = Vector2.Distance(gameObject.transform.position, tool.transform.position);
			if (distance < lowestDistance) {
				lowestDistance = distance;
				closestTool = tool;
			}
		}

		rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime * wornClothing.GetComponent<Clothing>().movementModifier);

	}

	public void SetInteractableObject(GameObject interactableObject) {
		this.interactableObject = interactableObject;
		if (interactableObject != null) {
			tooltip_Ctrl.enabled = true;
		} else {
			tooltip_Ctrl.enabled = false;
		}
		
	}
	public void SetNearbyClothing(GameObject nearbyClothing) {
		this.nearbyClothing = nearbyClothing;
	}
}
