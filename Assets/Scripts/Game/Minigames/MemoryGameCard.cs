using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class MemoryGameCard : MonoBehaviour {
    [HideInInspector] public bool flipped = false;
    [HideInInspector] public MemoryGameController.CardType type;
    [HideInInspector] public bool solved = false;

    [HideInInspector] public Image img;
    //private GameObject highlight;

    private void Start () {
        img = GetComponent<Image>();
        //highlight = transform.GetChild(0).gameObject;
    }

    private void Update () {
        //highlight.SetActive(EventSystem.current.currentSelectedGameObject == gameObject);
    }
}
