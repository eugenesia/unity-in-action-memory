using UnityEngine;
using System.Collections;

// Button to click to restart the game.
public class UIButton : MonoBehaviour {

	// Reference a target object to inform about clicks.
	[SerializeField] private GameObject targetObject;

	// Message to send to target object when clicked.
	[SerializeField] private string targetMessage;

	// Tint the button slightly on hover.
	public Color highlightColor = Color.cyan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseOver() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			// Tint button when mouse hovers over it.
			sprite.color = highlightColor;
		}
	}

	public void OnMouseExit() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			sprite.color = Color.white;
		}
	}

	// Button's size pops a bit when clicked.
	public void OnMouseDown() {
		transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp() {
		// Shrink button back to original size.
		transform.localScale = Vector3.one;
		if (targetObject != null) {
			// Send message to target object when clicked.
			targetObject.SendMessage(targetMessage);
		}
	}
}
