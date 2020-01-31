using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
	public enum ToolType {
		FireExtinguisher,
		WeldingMachine,
		Vacuum,
		Wrench,
		FlexTape,
		WindingKey,
		Flashlight,
		OverwriteTool
	}

	public ToolType toolType;
	private Rigidbody2D rigidbody;
	private SpriteRenderer renderer;

	// Throwing 
	private bool beingThrown = false;
	private Vector2 direction;
	private float currentThrowingtime = 0;
	public float throwingForce = 10f;		

    // Start is called before the first frame update
    void Start()
    {
		renderer = gameObject.GetComponent<SpriteRenderer>();
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate() {
		currentThrowingtime -= Time.fixedDeltaTime;
		if (currentThrowingtime <= 0) {
			beingThrown = false;
		}
		if (beingThrown) {
			if (Input.GetKey(KeyCode.Space)) {
				Vector2 force = direction * throwingForce;

				if (force.x != 0 && force.y != 0) {
					force *= 0.5f;
				}

				rigidbody.AddForce(force, ForceMode2D.Impulse);
			} else {
				beingThrown = false;
			}
		}

		
	}

	public GameObject PickUp() {
		//renderer.enabled = false;
		gameObject.SetActive(false);
		Debug.Log("Picked up: " + toolType);
		return gameObject;

	}

	public void Drop(Vector2 position, Vector2 direction, float throwingTime) {
		//renderer.enabled = true;
		gameObject.SetActive(true);
		beingThrown = true;
		currentThrowingtime = throwingTime;
		this.direction = direction;
		gameObject.transform.position = position;
		//gameObject.transform.forward = new Vector2(1, 0);
	}
}
