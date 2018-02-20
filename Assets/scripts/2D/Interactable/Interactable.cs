using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour {
    public virtual void Interact() {}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject && Player.Global.Interactable == this) {
            Player.Global.Interactable = null;
        }
    }
}