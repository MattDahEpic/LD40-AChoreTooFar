using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using UnityEngine;

public class ScaredMatt : MonoBehaviour {
    public SwfClipController render;

    void Update() {
        if (MemoryGameController.plays >= 5) render.PlayIfNotAlreadyPlaying("matt scared loop");
    }
}
