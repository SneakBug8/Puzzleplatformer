using UnityEngine;

public class Spikes : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Die();
        }
    }
}