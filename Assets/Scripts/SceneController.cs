using UnityEngine;
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


	// Use this for initialization
	void Start () {

		Vector3 startPos = originalCard.transform.position;

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

				int id = Random.Range(0, images.Length);
				// Set the card's image asset to a random one, and set
				// its ID to correspond to the selected image.
				card.SetCard(id, images[id]);

				// Place cloned card in the grid.
				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
