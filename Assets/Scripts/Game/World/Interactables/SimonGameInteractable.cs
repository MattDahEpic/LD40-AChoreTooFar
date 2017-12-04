using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGameInteractable : IInteractable {
    public GameObject simongamePrefab;
    public override void Interact(GameObject interactor) {
        CompletePlayerController.doControl = false;
        Instantiate(simongamePrefab);
    }
}
