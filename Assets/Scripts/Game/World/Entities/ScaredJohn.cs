using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using UnityEngine;

public class ScaredJohn : MonoBehaviour {
    public SwfClipController render;

    void Update() {
        if (QTEGameController.plays >= 4) render.PlayIfNotAlreadyPlaying("john scared loop");
    }
}
