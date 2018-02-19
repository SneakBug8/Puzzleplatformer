using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCollider : MonoBehaviour {

	public static void Match(GameObject obj) {
		Vector2 S = obj.GetComponent<SpriteRenderer>().sprite.bounds.size;
		obj.GetComponent<BoxCollider2D>().size = S;
		obj.GetComponent<BoxCollider2D>().offset = Vector2.zero;
	}
}
