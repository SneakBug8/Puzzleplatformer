using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [HideInInspector]    
    public Vector3 Direction = Vector3.right;
    [HideInInspector]
    public SpriteRenderer Renderer;
    [HideInInspector]
    public new Rigidbody2D rigidbody;
    [HideInInspector]    
    public new BoxCollider2D collider2D;
    public float JumpSpeed = 1f;
    public float Speed = 1F;
    public UnityEvent OnDeath = new UnityEvent();
    protected virtual void Start()
    {
        Renderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rigidbody = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        collider2D = GetComponent<BoxCollider2D>();
    }
    protected void Move(int direction = 0, float mod = 1)
    {
        if (direction != 0)
        {
            ChangeDirection(direction);
        }

        transform.Translate(new Vector2(Direction.x, 0) * Time.deltaTime * Speed * mod, Space.World);
    }

    protected void Jump()
    {
        rigidbody.AddForce(Vector2.up * JumpSpeed);
    }

#region Directions

    void ChangeDirection(string reason = "")
    {
        ChangeDirection(direction: (int) -Direction.x);
    }

    void ChangeDirection(int direction, string reason = "")
    {
        // Debug.Log("Changed direction because of " + reason);
        Direction.x = Mathf.Clamp(direction, -1, 1);
        Renderer.flipX = (Direction.x > 0) ? false : true;
    }
    
#endregion
#region Collisions
    public bool IsGrounded
    {
        get
        {
            return GroundColliders.Count > 0; ;
        }
    }
    List<Collider2D> GroundColliders = new List<Collider2D>();    
    void OnCollisionStay2D(Collision2D other)
    {
        if (!GroundColliders.Contains(other.collider))
            foreach (var p in other.contacts)
                if (p.point.y < collider2D.bounds.min.y)
                {
                    GroundColliders.Add(other.collider);
                    break;
                }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (GroundColliders.Contains(coll.collider))
            GroundColliders.Remove(coll.collider);
    }
#endregion
}