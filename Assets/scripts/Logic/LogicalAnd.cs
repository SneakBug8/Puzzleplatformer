using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class LogicalAnd : LogicalMiddleware {
	public override void Recount() {
		var res = true;
		foreach (var element in Elements) {
			res = res & element.Return;
		}

		Return = res;
	}
}
