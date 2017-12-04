using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonGameController : MonoBehaviour {
    public static int plays;

    public Sprite buttonSmile;
    public Image simonUp, simonDown, simonLeft, simonRight;

    private float time;
    private float blinkTime = 0.5f;
    private string simon = "";

	void Start () {
        //set up dimming
	    simonUp.color = Color.gray;
	    simonDown.color = Color.gray;
        simonLeft.color = Color.gray;
        simonRight.color = Color.gray;
        //decide on the buttons enabled
	    switch (plays) {
            default:
                simonUp.sprite = buttonSmile;
                goto case 3;
            case 3:
                simonRight.sprite = buttonSmile;
                goto case 2;
            case 2:
                simonLeft.sprite = buttonSmile;
                goto case 1;
            case 1:
                simonDown.sprite = buttonSmile;
                break;
            case 0: break;
	    }
        //start game
	    StartCoroutine(Game());
	}

    void Update () {
        time -= Time.deltaTime;
    }

    IEnumerator Game () {
        yield return null; //exit start
        //prevent breakage with no enabled buttons
        if (plays >= 4) {
            yield return new WaitForSeconds(3f);
            plays++;
            CompletePlayerController.doControl = true; //re-enable player control
            Destroy(gameObject); //and end the simongame
            yield break;
        }
        //blink previous buttons
        if (simon.Length > 0) {
            foreach (char c in simon) {
                switch (c) {
                    case '0':
                        simonUp.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonUp.color = Color.gray;
                        break;
                    case '1':
                        simonDown.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonDown.color = Color.gray;
                        break;
                    case '2':
                        simonLeft.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonLeft.color = Color.gray;
                        break;
                    case '3':
                        simonRight.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonRight.color = Color.gray;
                        break;
                }
                yield return new WaitForSeconds(0.1f); //distinguish sequential button presses
            }
        }
        //blink random button that is enabled
        while (true) {
            int butt = Random.Range(0, 4); //udlr
            switch (butt) {
                case 0:
                    if (simonUp.sprite != buttonSmile) {
                        simonUp.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonUp.color = Color.gray;
                        simon += "0";
                        goto getInput;
                    }
                    break;
                case 1:
                    if (simonDown.sprite != buttonSmile) {
                        simonDown.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonDown.color = Color.gray;
                        simon += "1";
                        goto getInput;
                    }
                    break;
                case 2:
                    if (simonLeft.sprite != buttonSmile) {
                        simonLeft.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonLeft.color = Color.gray;
                        simon += "2";
                        goto getInput;
                    }
                    break;
                case 3:
                    if (simonRight.sprite != buttonSmile) {
                        simonRight.color = Color.white;
                        yield return new WaitForSeconds(blinkTime);
                        simonRight.color = Color.gray;
                        simon += "3";
                        goto getInput;

                    }
                    break;
            }
        }
        getInput:
        time = 7f;
        int index = 0;
        while (time >= 0) {
            if (index < simon.Length) { //if not done pressing buttons
                if (Input.GetKeyDown(Key(simon[index]))) {
                    index++;
                    time = 7f;
                }
            } else {
                if (simon.Length >= 5) {
                    //win!
                    plays++;
                    CompletePlayerController.doControl = true; //re-enable player control
                    Destroy(gameObject); //and end the simongame
                } else {
                    StartCoroutine(Game());
                }
                yield break;
            }
            yield return null;
        }
        //failure
        CompletePlayerController.doControl = true; //re-enable player control
        Destroy(gameObject); //and end the simongame
    }

    KeyCode Key (char key) {
        switch (key) {
            case '0': return KeyCode.W;
            case '1': return KeyCode.S;
            case '2': return KeyCode.A;
            case '3': return KeyCode.D;
        }
        return KeyCode.None;
    }
}
