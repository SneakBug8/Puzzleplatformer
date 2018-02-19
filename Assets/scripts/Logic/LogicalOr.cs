using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalOr : LogicalMiddleware {
	public override void Recount() {
		var res = false;
		foreach (var element in Elements) {
			res = res || element.Return;
		}

		Return = res;
	}
}
