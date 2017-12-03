using System;
using System.Collections;
using System.Collections.Generic;
using FTRuntime;
using Random = UnityEngine.Random;

public static class ExtensionMethods {
    public static void PlayIfNotAlreadyPlaying(this SwfClipController controller, string sequence) {
        if (controller.clip.sequence != sequence) controller.Play(sequence);
    }

    public static T RandomElement<T> (this List<T> list) {
        if (list.Count == 0) throw new Exception("Cannot select random element from list with no elements!");
        return list[Random.Range(0, list.Count)];
    }
}
