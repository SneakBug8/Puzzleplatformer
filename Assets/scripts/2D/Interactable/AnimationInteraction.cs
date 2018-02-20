using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationInteraction : Interactable {
	Animator Animator;

	public string Trigger;
	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator>();
	}
	
	public override void Interact() {
		Animator.SetTrigger(Trigger);
	}
}
