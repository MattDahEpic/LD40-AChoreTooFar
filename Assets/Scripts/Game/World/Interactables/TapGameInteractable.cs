using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGameInteractable : IInteractable {
    public GameObject tapgamePrefab;
    public override void Interact (GameObject interactor) {
        CompletePlayerController.doControl = false;
        Instantiate(tapgamePrefab);
    }
}
