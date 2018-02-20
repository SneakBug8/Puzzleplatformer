using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {
     public Transform Target;
    public float Velocity;
    public Vector3 Offset;
    public float MinDistance;
    void LateUpdate () {
        if (Target == null)
        {
			return;
		}

		var targetPos = Target.transform.position + Offset;

		if (Vector3.Distance(transform.position, targetPos) < MinDistance) {
			return;
		}
		var newPos = Vector3.MoveTowards(transform.position, targetPos, Velocity * Time.deltaTime);

		transform.position = newPos;
     }
 }