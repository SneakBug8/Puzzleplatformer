using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicalButton : LogicalElement {
	new SpriteRenderer renderer;

	public Sprite SpriteNormal;
	public Sprite SpritePressed;

	private void Start() {
		renderer = GetComponent<SpriteRenderer>();
	}

	List<Collider2D> CollidersOnButton = new List<Collider2D>();
    void OnTriggerEnter2D(Collider2D other)
	{
		Return = true;
		renderer.sprite = SpritePressed;
		CollidersOnButton.Add(other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		CollidersOnButton.Remove(other);
		if (CollidersOnButton.Count == 0) {
			Return = false;
			renderer.sprite = SpriteNormal;
			
		}
	}
}
