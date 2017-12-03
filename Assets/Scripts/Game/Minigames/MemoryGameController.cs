using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryGameController : MonoBehaviour {
    public static int plays;

    public Sprite cardEmpty, cardBack, cardSpade, cardHeart, cardDiamond, cardClub, cardStar;
    public MemoryGameCard[] cardPlaces;

    private MemoryGameCard flipped = null;
    private int pairs = 5, matched;

    public enum CardType { SPADE, HEART, DIAMOND, CLUB, STAR }

	IEnumerator Start () {
		//decide how many types
	    int typeCount = 5 - plays;
	    if (typeCount <= 0) typeCount = 1;
	    List<CardType> selectedTypes = new List<CardType>{CardType.SPADE,CardType.HEART,CardType.DIAMOND,CardType.CLUB,CardType.STAR};
	    for (int i = 0; i < 5 - typeCount; i++) {
	        selectedTypes.Remove(selectedTypes.RandomElement());
	    }
	    //fill array with those types
	    try {
	        IEnumerator cards = cardPlaces.GetEnumerator();
	        cards.MoveNext();
	        do {
	            CardType type = selectedTypes.RandomElement();
	            ((MemoryGameCard) cards.Current).type = type;
	            cards.MoveNext();
	            ((MemoryGameCard) cards.Current).type = type;
	            cards.MoveNext();
	        } while (cards.Current != null);
	    } catch (InvalidOperationException) { } //jam code!
	    yield return null; //wait for spacebar release
	    EventSystem.current.SetSelectedGameObject(cardPlaces[0].gameObject);
        //TODO time?
    }
	
	void Update () {
	    if (matched >= pairs) {
	        plays++;
	        CompletePlayerController.doControl = true; //re-enable player control
	        Destroy(gameObject); //and end the memorygame
        }
	}

    public void CardClick () {
        StartCoroutine(DoClick());
    }
    public IEnumerator DoClick () {
        MemoryGameCard flip = EventSystem.current.currentSelectedGameObject.GetComponent<MemoryGameCard>();
        if (flip.flipped || flip.solved) yield break; //dont do anything if already flipped or already solved
        //flip card
        flip.img.sprite = GetImgForType(flip.type);
        if (flipped == null) { //if the first flip
            flipped = flip;
            yield break;
        }
        GameObject sel = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForSeconds(0.5f);
        EventSystem.current.SetSelectedGameObject(sel);
        if (flip.type == flipped.type) {//same type
            flipped.img.sprite = cardEmpty;
            flipped.solved = true;
            flip.img.sprite = cardEmpty;
            flip.solved = true;
            matched++;
        } else { //not same type
            flipped.img.sprite = cardBack;
            flip.img.sprite = cardBack;
        }
        flipped = null;
    }

    private Sprite GetImgForType (CardType type) {
        switch (type) {
            case CardType.CLUB: return cardClub;
            case CardType.DIAMOND: return cardDiamond;
            case CardType.HEART: return cardHeart;
            case CardType.SPADE: return cardSpade;
            case CardType.STAR: return cardStar;
        }
        return null;
    }
}
