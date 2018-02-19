using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalMiddleware : LogicalElement {
	public LogicalElement[] Elements;

    void Start()
    {
        foreach (var element in Elements) {
            element.OnChange.AddListener(Recount);
        }
    }
    public virtual void Recount() {}
}
