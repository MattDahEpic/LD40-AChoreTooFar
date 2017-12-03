using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using UnityEngine;

public static class ExtensionMethods {
    public static void PlayIfNotAlreadyPlaying(this SwfClipController controller, string sequence) {
        if (controller.clip.sequence != sequence) controller.Play(sequence);
    }
}
