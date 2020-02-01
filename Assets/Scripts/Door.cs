using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public enum Direction {
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public Direction direction;

	private Collider2D collider;
	public float openOffset;
	public float openingSpeed;
	private float currentOffset;
	private Vector2 originalPosition;
	private bool opening;
	private bool closing;
	private Vector2 currentPos;

	private void Start() {
		collider = gameObject.GetComponent<Collider2D>();
		originalPosition = transform.position;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.L)) {
			Open();
		}
		if (Input.GetKeyDown(KeyCode.P)) {
			Close();
		}
	}

	void FixedUpdate()
    {
		if (opening) {
			currentPos = transform.position;
			currentOffset += openingSpeed * Time.deltaTime;

			if (direction == Direction.RIGHT) {
				currentPos.x += openingSpeed * Time.deltaTime;
				if (currentPos.x > openOffset + originalPosition.x) {
					currentPos.x = openOffset + originalPosition.x;
					opening = false;
				}
			} else if (direction == Direction.LEFT) {
				currentPos.x -= openingSpeed * Time.deltaTime;
				if (currentPos.x < originalPosition.x - openOffset) {
					currentPos.x = originalPosition.x - openOffset;
					opening = false;
				}
			} else if (direction == Direction.UP) {
				currentPos.y += openingSpeed * Time.deltaTime;
				if (currentPos.y > openOffset + originalPosition.y) {
					currentPos.y = openOffset + originalPosition.y;
					opening = false;
				}
			} else if (direction == Direction.DOWN) {
				currentPos.y -= openingSpeed * Time.deltaTime;
				if (currentPos.y < originalPosition.y - openOffset) {
					currentPos.y = originalPosition.y - openOffset;
					opening = false;
				}
			}

			transform.position = currentPos;
		} else if (closing) {
			currentPos = transform.position;
			currentOffset -= openingSpeed * Time.deltaTime;

			if (direction == Direction.RIGHT) {
				currentPos.x -= openingSpeed * Time.deltaTime;
				if (currentPos.x < originalPosition.x) {
					currentPos.x = originalPosition.x;
					closing = false;
				}
			}
			else if (direction == Direction.LEFT) {
				currentPos.x += openingSpeed * Time.deltaTime;
				if (currentPos.x > originalPosition.x) {
					currentPos.x = originalPosition.x;
					closing = false;
				}
			}
			else if(direction == Direction.UP) {
				currentPos.y -= openingSpeed * Time.deltaTime;
				if (currentPos.y < originalPosition.y) {
					currentPos.y = originalPosition.y;
					closing = false;
				}
			}
			else if(direction == Direction.DOWN) {
				currentPos.y += openingSpeed * Time.deltaTime;
				if (currentPos.y > originalPosition.y) {
					currentPos.y = originalPosition.y;
					closing = false;
				}
			}


			transform.position = currentPos;
		}
    }

	public void Open() {
		//collider.enabled = false;
		opening = true;
		closing = false;
	} 

	public void Close() {
		//collider.enabled = true;
		opening = false;
		closing = true;
	}
}
