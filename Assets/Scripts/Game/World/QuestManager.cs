using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {
    public GameObject questDialog;
    public Text text;

	void Update () {
	    if (TapGameController.plays <= 6) {
	        text.text = "Work out with Gendy!";
	    } else if (TapGameController.plays > 6 && MemoryGameController.plays < 5) {
	        text.text = "Remember with Matt!";
	    } else if (MemoryGameController.plays >= 5 && QTEGameController.plays < 4) {
	        text.text = "Shop with John!";
	    } else if (QTEGameController.plays >= 4 && SimonGameController.plays <= 3) {
	        text.text = "Do whatever your wife is asking!";
	    } else {
	        questDialog.SetActive(false);
	    }
	}
}
