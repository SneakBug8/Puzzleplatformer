using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Antigravity : MonoBehaviour {
	List<Rigidbody2D> Rigidbodies = new List<Rigidbody2D>();
	public Vector2 Speed = new Vector2(0,1);
	private void OnTriggerEnter2D(Collider2D other) {
		var rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
		if (rigidbody != null) {
			Rigidbodies.Add(rigidbody);
		}
	}
	private void OnTriggerStay2D(Collider2D other) {
		foreach(var rigidbody in Rigidbodies) {
			rigidbody.velocity = Speed;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		for (int i = 0; i < Rigidbodies.Count; i++) {
			if (Rigidbodies[i].gameObject == other.gameObject) {
				Rigidbodies.RemoveAt(i);
				return;
			}
		}
	}
}
