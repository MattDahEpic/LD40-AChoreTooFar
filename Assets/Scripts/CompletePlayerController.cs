using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		//gether the current inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		//and set velocity
	    rb2d.velocity = movement*speed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive(false);
		}
	}
}
