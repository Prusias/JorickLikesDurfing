using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public GameObject[] tools;
	public GameObject closestTool;
	public GameObject heldTool;
	public float lowestDistance = Mathf.Infinity;
	public float pickupDistance = 0.5f;
	public GameObject interactableObject;
	public float throwingTime = .25f;


    // Start is called before the first frame update
    void Start()
    {
		tools = GameObject.FindGameObjectsWithTag("Tool");


		//collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
			if (heldTool != null) {
				heldTool.GetComponent<Tool>().Drop(gameObject.transform.position, gameObject.GetComponent<Movement>().movement, throwingTime);
				heldTool = null;
			} else {
				if (lowestDistance < pickupDistance) {
					heldTool = closestTool.GetComponent<Tool>().PickUp();
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			if(interactableObject != null) {
				interactableObject.GetComponent<IInteractable>().Interract(heldTool.GetComponent<Tool>().toolType);
			}
		}


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
	}

	public void SetInteractableObject(GameObject interactableObject) {
		this.interactableObject = interactableObject;
	}
}
