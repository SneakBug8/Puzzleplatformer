using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicalElement : MonoBehaviour {
	public bool Return { get {
		return state;
	} set {
		if (state != value) {
			state = value;
			OnChange.Invoke();
		}
	}}
	private bool state;

	public UnityEvent OnChange;

	public virtual void OnDrawGizmosSelected() {
		
	}

	public Color Color {
		get {
			if (Return) {
				return Color.green;
			} else {
				return Color.red;
			}
		}
	}
}
