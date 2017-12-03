using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameInteractable : IInteractable {
    public GameObject memorygamePrefab;
    public override void Interact(GameObject interactor) {
        CompletePlayerController.doControl = false;
        Instantiate(memorygamePrefab);
    }
}
