﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
	public virtual bool Active() {
		return false;
	}
}