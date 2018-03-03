using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalMiddleware : LogicalElement
{
    public LogicalElement[] Elements;

    void Start()
    {
        foreach (var element in Elements)
        {
            element.OnChange.AddListener(Recount);
        }
    }
    public override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (var element in Elements)
        {
            if (element == null) {
                continue;
            }
            Gizmos.DrawWireCube(element.transform.position, new Vector3(1, 1, 1));
            Gizmos.DrawLine(transform.position, element.transform.position);
            element.OnDrawGizmosSelected();
        }
    }
    public virtual void Recount() { }
}
