using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class TextTrigger : MonoBehaviour {
	public string TextString;
	public StoryText Text;
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == Player.Global.gameObject) {
			Text.PrintText(TextString).SetFade(true).DisableAfterTime(5f).Enable();
		}
	}
}
