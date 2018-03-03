using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalEnd : LogicalElement {
	public LogicalElement Element;

    void Awake()
    {
        Element.OnChange.AddListener(Process);
    }

    public override void OnDrawGizmosSelected() {
        if (Element == null) {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Element.transform.position, new Vector3(1,1,1));
        Gizmos.DrawLine(transform.position, Element.transform.position);
        Element.OnDrawGizmosSelected();
    }
    public virtual void Process() {}
}
