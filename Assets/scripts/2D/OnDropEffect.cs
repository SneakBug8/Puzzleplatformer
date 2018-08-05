using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDropEffect : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    public GameObject DropParticle;
    Vector2 prevVelocity;
    new Collider2D collider2D;
    GameObject[] Particles = new GameObject[2];
    [Range(0, 2)]
    public float SpeedModifier = 1;
    [Range(0, 2)]
    public float XModifier = 1;

    float untilDestroy;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        prevVelocity = rigidbody2D.velocity;
        untilDestroy -= Time.deltaTime;
        if (untilDestroy <= 0)
        {
            if (Particles[0] != null)
            {
                Destroy(Particles[0]);
            }
            if (Particles[1] != null)
            {
                Destroy(Particles[1]);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (prevVelocity.magnitude < 5)
        {
            return;
        }

        if (Particles[0] == null)
        {
            var LeftParticleForce = new Vector2(prevVelocity.y * XModifier, -prevVelocity.y) * SpeedModifier;
            Particles[0] = Instantiate(DropParticle, collider2D.bounds.min, Quaternion.identity);
            Particles[0].GetComponent<Rigidbody2D>().AddForce(LeftParticleForce);
            untilDestroy = 1f;
        }
        if (Particles[1] == null)
        {
            var RightCorner = new Vector2(collider2D.bounds.max.x, collider2D.bounds.min.y);
            var RightParticleForce = new Vector2(-prevVelocity.y * XModifier, -prevVelocity.y) * SpeedModifier;
            Particles[1] = Instantiate(DropParticle, RightCorner, Quaternion.identity);
            Particles[1].GetComponent<Rigidbody2D>().AddForce(RightParticleForce);
            untilDestroy = 1f;
        }

    }
}
