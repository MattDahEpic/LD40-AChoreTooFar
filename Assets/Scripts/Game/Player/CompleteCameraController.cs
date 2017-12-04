using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompleteCameraController : MonoBehaviour {
    public Text uiText;

	public GameObject player;		//Public variable to store a reference to the player game object

	private Vector3 offset;			//Private variable to store the offset distance between the player and camera

	void Start () {
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
        //set mouse state
	    Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;
    }
	
	void LateUpdate () {
        //do mouse hiding
	    if (Input.GetKeyDown(KeyCode.Escape)) {
	        Cursor.lockState = CursorLockMode.None;
	        Cursor.visible = true;
	    } else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) {
	        Cursor.lockState = CursorLockMode.Locked;
	        Cursor.visible = false;
	    }
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
        //do ui
	    uiText.text = "<color=#ff00ff>" + TapGameController.plays + "</color> workouts\n" +
	                  "<color=#ff00ff>" + MemoryGameController.plays + "</color> memories\n" +
	                  "<color=#ff00ff>"+QTEGameController.plays+"</color> shoppings" +
	                  "";
	}
}
