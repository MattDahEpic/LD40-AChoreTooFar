using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapGameController : MonoBehaviour {
    public static int plays;

    public int taps, tapGoal;
    public Sprite tapBGUp, tapBGDown, tapBGBroke;
    public Text tapRemain;
    public Image tapBG;
	void Start () {
	    taps = 0;
	    tapGoal = 30-plays*5;
        //TODO time?
	}
	
	void Update () {
	    tapRemain.text = tapGoal - taps + " remaining!";
	    tapBG.sprite = tapGoal == 0 ? tapBGBroke : Input.GetKey(KeyCode.Space) ? tapBGDown : tapBGUp;
	    if (Input.GetKeyDown(KeyCode.Space)) taps++;
	    if (taps >= tapGoal) {
	        plays++;
	        CompletePlayerController.doControl = true; //re-enable player control
            Destroy(gameObject); //and end the tapgame
	    }
	}
}
