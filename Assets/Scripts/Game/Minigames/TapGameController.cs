using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapGameController : MonoBehaviour {
    public int taps, tapGoal, round;
    public Text tapRemain;
	void Start () {
	    taps = 0;
	    tapGoal = 15; //TODO get level correct tapgoal
	    round = 0;
	}
	
	void Update () {
	    tapRemain.text = string.Format("Tap {F} times!",tapGoal-taps);
	    if (Input.GetKeyDown(KeyCode.Space)) taps++;
	    if (taps > tapGoal) {
	        round++;
	        taps = 0;
            //TODO find new tapgoal
	        if (round >= 3) {
	            //TODO add player xp
	            CompletePlayerController.doControl = true;
                Destroy(gameObject);
	        }
	    }
	}
}
