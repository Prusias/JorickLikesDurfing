using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
	public enum ToolType {
		TestTool,
		TestTool2
	}

	public ToolType toolType;
	private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
		renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public GameObject PickUp() {
		//renderer.enabled = false;
		gameObject.SetActive(false);
		Debug.Log("Picked up: " + toolType);
		return gameObject;

	}

	public void Drop(Vector2 position) {
		//renderer.enabled = true;
		gameObject.SetActive(true);
		gameObject.transform.position = position;
	}
}
