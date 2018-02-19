using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalEnd : LogicalElement {
	public LogicalElement Element;

    void Awake()
    {
        Element.OnChange.AddListener(Process);
    }
    public virtual void Process() {}
}
