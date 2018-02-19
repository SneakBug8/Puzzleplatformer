using UnityEngine;

public class Teleport : MonoBehaviour {
    public Vector2 Destination;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Destination, new Vector3(1,1,1));
        Gizmos.DrawLine(transform.position, Destination);
    }
    public void Activate(GameObject subject) {
        subject.transform.position = new Vector3(Destination.x, Destination.y, subject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearTeleport = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == Player.Global.gameObject) {
            Player.Global.Interactions.NearTeleport = null;
        }
    }
}