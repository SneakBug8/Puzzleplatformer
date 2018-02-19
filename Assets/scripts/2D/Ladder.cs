using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ladder : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearLadder = false;
        }
    }
}