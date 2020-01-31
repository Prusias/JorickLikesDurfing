using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
	public void OnTriggerEnter2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(gameObject);
	}

	public void OnTriggerExit2D(Collider2D collision) {
		collision.gameObject.GetComponent<Player>().SetInteractableObject(null);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
