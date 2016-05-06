using UnityEngine;
using System.Collections;

// Scene controller to coordinate card actions.
public class SceneController : MonoBehaviour {

	// Reference for the original card in the scene, to be cloned.
	[SerializeField] private MemoryCard originalCard;

	// Array of references to the sprite assets.
	[SerializeField] private Sprite[] images;


	// Use this for initialization
	void Start () {
		int id = Random.Range(0, images.Length);
		// Set the original card's image asset to a random one, and set
		// its ID to correspond to the selected image.
		originalCard.SetCard(id, images[id]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
