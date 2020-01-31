using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public Rigidbody2D rb;

	public float movementSpeed = 5f;

	public Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
		movement.y = Input.GetAxisRaw("Vertical"); // -1 is down

	}

	void FixedUpdate() {
		rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
	}
}
