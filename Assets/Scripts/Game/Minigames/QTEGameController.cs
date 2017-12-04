using UnityEngine;
using UnityEngine.UI;

public class QTEGameController : MonoBehaviour {
    public static int plays;

    public Sprite keyW, keyA, keyS, keyD, keySmile;
    public Image keyPlace;
    public float pressTime = 5f;

    private int currentPlace;
    private string keyString = "";
    private float time;

	// Use this for initialization
	void Start () {
        //get which characters we get
	    string selecables;
	    switch (plays) {
            case 0: selecables = "wasd"; break;
            case 1: selecables = "was"; break;
            case 2: selecables = "wa"; break;
            case 3: selecables = "w"; break;
            default: selecables = "m"; break;
	    }
        //select which ones get chosed
	    for (int i = 0; i < 8; i++) {
	        keyString += selecables[Random.Range(0, selecables.Length)];
	    }
        Debug.Log(keyString);
        //setup first character
        SetKey(keyString[0]);
	    time = pressTime;
	}
	
	void Update () {
	    time -= Time.deltaTime;
	    if (keyString.Length > 0) {
	        if (Input.GetKeyDown(KCode(keyString[0]))) {
	            keyString = keyString.Substring(1);
	            if (keyString.Length != 1) SetKey(keyString[0]);
	            else keyString = "";
	            time = pressTime;
	        }
	        if (time <= 0) {
	            //fail if run out of time
	            CompletePlayerController.doControl = true; //re-enable player control
	            Destroy(gameObject); //and end the QTEgame
	        }
	    } else { //win
            plays++;
	        CompletePlayerController.doControl = true; //re-enable player control
	        Destroy(gameObject); //and end the QTEgame
	    }
	}

    void SetKey (char key) {
        switch (key) {
            case 'w': keyPlace.sprite = keyW;
                break;
            case 'a': keyPlace.sprite = keyA;
                break;
            case 's': keyPlace.sprite = keyS;
                break;
            case 'd': keyPlace.sprite = keyD;
                break;
            case 'm': keyPlace.sprite = keySmile;
                break;
        }
    }

    KeyCode KCode (char key) {
        switch (key) {
            case 'w': return KeyCode.W;
            case 'a': return KeyCode.A;
            case 's': return KeyCode.S;
            case 'd': return KeyCode.D;
        }
        return KeyCode.None;
    }
}
