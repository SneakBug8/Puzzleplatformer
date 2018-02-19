using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))][RequireComponent(typeof(Animator))]
public class KeyDoor : MonoBehaviour, IDoor {
	protected Animator Animator;
	public Key Key;
	private string KeyId;
	void Start()
	{
		Animator = GetComponent<Animator>();
		KeyId = Key.Id;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == Player.Global.gameObject &&
			Player.Global.Keys.Contains(KeyId)) {
			Open();
		}
	}

	public void Open() {
		Animator.SetTrigger("Open");
	}

	public void Close() {
		Animator.SetTrigger("Close");
	}
}
