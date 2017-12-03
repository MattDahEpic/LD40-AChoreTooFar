using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using UnityEngine;

public class ScaredGendy : MonoBehaviour {
    public SwfClipController render;
	
	void Update () {
		if (TapGameController.plays > 6) render.PlayIfNotAlreadyPlaying("gendy scared loop");
	}
}
