using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicalButton : LogicalElement {
    void OnTriggerEnter2D(Collider2D other)
	{
		Return = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Return = false;
	}
}
