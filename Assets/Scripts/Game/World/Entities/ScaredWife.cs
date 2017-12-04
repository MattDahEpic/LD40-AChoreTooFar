using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using UnityEngine;

public class ScaredWife : MonoBehaviour {
    public SwfClipController render;

    void Update() {
        if (SimonGameController.plays > 3) render.PlayIfNotAlreadyPlaying("wife scared loop");
    }
}
