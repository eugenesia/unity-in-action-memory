﻿using UnityEngine;
using System.Collections;

// Scene controller to coordinate card actions.
public class SceneController : MonoBehaviour {

	// Grid to place cloned cards.
	public const int gridRows = 2;
	public const int gridCols = 4;

	// Spacing between cards.
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	// Reference for the original card in the scene, to be cloned.
	[SerializeField] private MemoryCard originalCard;

	// Array of references to the sprite assets.
	[SerializeField] private Sprite[] images;

	// Keep track of revealed cards.
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;

	private int _score = 0;


	// Getter function that returns false if there's already a 2nd
	// card revealed.
	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	// For a card to inform the controller that it has been revealed,
	// for tracking purposes.
	public void CardRevealed(MemoryCard card) {
		// Store card objects in one of the two card variables, depending on
		// if the first variable is already occupied.
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			// Compare IDs of the 2 revealed cards to check for match.
			Debug.Log("Match? " + (_firstRevealed.id == _secondRevealed.id));
			StartCoroutine(CheckMatch());
		}
	}

	// Restart the level.
	public void Restart() {
		// Scene asset named "Scene1" is loaded with this command.
		Application.LoadLevel("Scene1");
	}

	// Use this for initialization
	void Start () {

		Vector3 startPos = originalCard.transform.position;

		// Pair of IDs for all 4 card sprites.
		int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
		numbers = ShuffleArray(numbers);

		// Clone the original card and place it on the grid.
		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {

				MemoryCard card;

				if (i == 0 && j == 0) {
					card = originalCard;
				} else {

					// Clone the Memory Card GameObject by cloning its attached Component.
					// If you are cloning a Component, then the GameObject it
					// is attached to will also be cloned.
					// http://docs.unity3d.com/ScriptReference/Object.Instantiate.html
					card = Instantiate(originalCard) as MemoryCard;
				}

				// Retrive IDs from the shuffled list instead of random numbers.
				int index = j * gridCols + i;
				int id = numbers[index];

				// Set card's ID to correspond to the selected image.
				card.SetCard(id, images[id]);

				// Place cloned card in the grid.
				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}

	// Knuth shuffle algorithm to shuffle an int array.
	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone() as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Check for matches and hide non-matching revealed cards.
	private IEnumerator CheckMatch() {
		// Increment score if revealed cards match.
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
			Debug.Log("Score: " + _score);
		}
		else {
			// Pause for half a second for user to see and remember mismatched
			// cards.
			yield return new WaitForSeconds(.5f);

			// Hide cards if they don't match.
			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}

		// Clear out the variables whether or not a match was made.
		_firstRevealed = null;
		_secondRevealed = null;
	}
}
