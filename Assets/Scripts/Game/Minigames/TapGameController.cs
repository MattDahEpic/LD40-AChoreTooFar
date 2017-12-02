using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapGameController : MonoBehaviour {
    public int taps, tapGoal;
    public Sprite tapBGUp, tapBGDown;
    public Text tapRemain;
    public Image tapBG;
	void Start () {
	    taps = 0;
	    tapGoal = 30; //TODO get level correct tapgoal
        //TODO time?
	}
	
	void Update () {
	    tapRemain.text = tapGoal - taps + " remaining!";
	    tapBG.sprite = Input.GetKey(KeyCode.Space) ? tapBGDown : tapBGUp;
	    if (Input.GetKeyDown(KeyCode.Space)) taps++;
	    if (taps > tapGoal) {
            //TODO add player xp
	        CompletePlayerController.doControl = true; //re-enable player control
            Destroy(gameObject); //and end the tapgame
	    }
	}
}
