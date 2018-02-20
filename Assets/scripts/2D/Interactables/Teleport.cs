using UnityEngine;

public class Teleport : Interactable {
    public Vector2 Destination;
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Destination, new Vector3(1,1,1));
        Gizmos.DrawLine(transform.position, Destination);
    }
    public override void Interact() {
        Player.Global.transform.position = new Vector3(Destination.x, Destination.y, Player.Global.transform.position.z);
    }
}