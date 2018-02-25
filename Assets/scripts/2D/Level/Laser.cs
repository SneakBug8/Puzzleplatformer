using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class Laser : MonoBehaviour {
    List<Rigidbody2D> Rigidbodies = new List<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D other) {
        var rigidbody = other.GetComponent<Rigidbody2D>();
        if (rigidbody != null) {
            Rigidbodies.Add(rigidbody);
        }
    }

    private void Update() {
        while (Rigidbodies.Contains(null)) {
            Rigidbodies.Remove(null);
        }
        foreach (var rigidbody in Rigidbodies) {
            rigidbody.velocity = rigidbody.velocity / 2;
            rigidbody.transform.localScale =
            Vector3.Lerp(rigidbody.transform.localScale, Vector3.zero, 0.01f);

            if (rigidbody.transform.localScale.magnitude < 0.5f && rigidbody.gameObject != Player.Global.gameObject) {
                Destroy(rigidbody.gameObject);
            }
        }
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Die();
        }
    }
}