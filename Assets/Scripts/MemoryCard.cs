using UnityEngine;
using System.Collections;

// React to clicks by turning over.
public class MemoryCard : MonoBehaviour {

	// Sprite representing back of the card.
	[SerializeField] private GameObject cardBack;

	// Sprite asset that will be loaded.
	[SerializeField] private Sprite image;

	// Use this for initialization
	void Start () {
		// Set the sprite for this SpriteRender component.
		GetComponent<SpriteRenderer>().sprite = image;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnMouseDown() {

		// Only deactivate if object is currently active/visible.
		if (cardBack.activeSelf) {
			// Set object inactive/invisible.
			cardBack.SetActive(false);
		}
	}
}
