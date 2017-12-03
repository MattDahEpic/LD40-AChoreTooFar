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

    private bool done = false;
	IEnumerator Start () {
	    taps = 0;
	    tapGoal = 30-plays*5;
	    yield return new WaitForSeconds(0.5f); //wait for spacebar
	    //TODO time?
	}
	
	void Update () {
	    tapRemain.text = (tapGoal - taps+1) <= 0 ? "Done!" : (tapGoal - taps+1) + " remaining!";
	    tapBG.sprite = tapGoal <= 0 ? tapBGBroke : Input.GetKey(KeyCode.Space) ? tapBGDown : tapBGUp;
	    if (Input.GetKeyDown(KeyCode.Space)) taps++;
	    if (taps > tapGoal && !done) {
	        done = true;
	        StartCoroutine(EndGame());
	    }
	}

    IEnumerator EndGame () {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        plays++;
        CompletePlayerController.doControl = true; //re-enable player control
        Destroy(gameObject); //and end the tapgame
    }
}
