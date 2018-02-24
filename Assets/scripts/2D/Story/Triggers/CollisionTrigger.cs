using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionTrigger : Trigger
{
    bool activated = false;

    public override bool Active()
    {
        return activated;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player.Global.gameObject)
        {
            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == Player.Global.gameObject)
        {
            activated = false;
        }
    }
}