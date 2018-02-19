using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LogicalDoor : LogicalEnd, IDoor {
	public bool AutoClose;
	protected Animator Animator;
	void Start()
	{
		Animator = GetComponent<Animator>();
	}

	public override void Process() {
		if (Element.Return) {
			Open();
		}
		else if (!Element.Return && AutoClose) {
			Close();
		}
	}

	public void Open() {
		Animator.SetTrigger("Open");
	}

	public void Close() {
		Animator.SetTrigger("Close");
	}
}
