using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Ladder : Interactable {
    public override void Interact() {
        Climb();       
    }

    protected void Climb() {
        Player.Global.transform.Translate(new Vector2(0,1) / 2 * Time.deltaTime * Player.Global.Speed, Space.World);
        Player.Global.rigidbody.velocity = Vector2.zero;         
    }
}