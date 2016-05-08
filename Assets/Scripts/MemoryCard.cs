using UnityEngine;
using System.Collections;

// React to clicks by turning over.
public class MemoryCard : MonoBehaviour {

	// Sprite representing back of the card.
	[SerializeField] private GameObject cardBack;

	// SceneController to coordinate card actions.
	[SerializeField] private SceneController controller;

	// ID of the sprite used in the card.
	private int _id;
	public int id {
		get {return _id;}
	}


	// Public method that other scripts can use to pass new sprites to
	// this object.
	public void SetCard(int id, Sprite image) {
		_id = id;
		// Change the image used on this object.
		GetComponent<SpriteRenderer>().sprite = image;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnMouseDown() {

		// Only deactivate if object is currently active/visible.
		// Check the controller's canReveal property, to make sure only
		// two cards are revealed at a time.
		if (cardBack.activeSelf && controller.canReveal) {

			// Set object inactive/invisible.
			cardBack.SetActive(false);

			// Notify controller when this card is revealed.
			controller.CardRevealed(this);
		}
	}

	// For SceneController to hide the card again (by turning card_back
	// back on.
	public void Unreveal() {
		cardBack.SetActive(true);
	}
}
