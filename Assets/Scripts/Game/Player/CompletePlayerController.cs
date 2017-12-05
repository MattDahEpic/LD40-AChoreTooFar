using UnityEngine;
using System.Collections;
using FTRuntime;
using UnityEngine.UI;

public class CompletePlayerController : MonoBehaviour {
    public static bool doControl = true;

	public float speed;
    public GameObject interactText;
    public SwfClipController render;

	private Rigidbody2D rb2d;
    private bool swole { get { return TapGameController.plays > 6 && MemoryGameController.plays >= 5 && QTEGameController.plays >= 4 && SimonGameController.plays > 3; } }
    private string idle_str { get { return swole ? "jake muscle idle" : "jack_idle"; } }
    private string walk_str { get { return swole ? "jake muscle run" : "jack_walk"; } }

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	    interactText.SetActive(false);
    }

	void FixedUpdate () {
		//gether the current inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		//and set velocity
	    if (doControl) rb2d.velocity = movement*speed;
        else rb2d.velocity = Vector2.zero;
        //and set the render
	    if (rb2d.velocity != Vector2.zero) {
	        render.PlayIfNotAlreadyPlaying(walk_str);
	        if (rb2d.velocity.x > 0) { //moving right
	            render.transform.localScale = new Vector3(-3,3,3);
            } else { // moving left
	            render.transform.localScale = new Vector3(3,3,3);
            }
	    } else {
	        render.PlayIfNotAlreadyPlaying(idle_str);
	    }
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Interactable")) {
            interactText.SetActive(true); //show interact control prompt
            if (Input.GetKeyDown(KeyCode.Space) && doControl) other.GetComponent<IInteractable>().Interact(gameObject);
		}
	}

    void OnTriggerExit2D (Collider2D other) {
        interactText.SetActive(false); //hide interact control prompt
    }
}
