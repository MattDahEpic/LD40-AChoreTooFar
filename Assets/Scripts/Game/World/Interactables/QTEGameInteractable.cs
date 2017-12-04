using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEGameInteractable : IInteractable {
    public GameObject QTEgamePrefab;
    public override void Interact(GameObject interactor) {
        CompletePlayerController.doControl = false;
        Instantiate(QTEgamePrefab);
    }
}
