using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Key : MonoBehaviour {
	[HideInInspector]
	public string Id;
	void Awake() {
		Id = gameObject.name + gameObject.tag + Random.Range(0,65000);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == Player.Global.gameObject) {
			Player.Global.Keys.Add(Id);
			Destroy(gameObject);
		}
	}
}
