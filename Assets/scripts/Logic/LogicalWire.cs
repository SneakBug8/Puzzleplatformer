using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalWire : LogicalElement {
	public LogicalElement From;
	public LogicalElement To;

	LineRenderer Renderer;

	void Start()
	{
		Renderer = GetComponent<LineRenderer>();
	}

	public void Update()
	{
		if (From == null) {
			return;
		}

		Renderer.startColor = From.Color;
		Return = From.Return;

		if (To != null) {
			Renderer.endColor = To.Color;
		} else {
			Renderer.endColor = From.Color;
		}
	}
}
