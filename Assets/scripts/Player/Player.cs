﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{
    public static Player Global;
    [HideInInspector]
    void Awake()
    {
        Global = this;
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public PlayerInteractions Interactions = new PlayerInteractions();

    public List<string> Keys = new List<string>();
    public UnityEvent OnKeysChange = new UnityEvent();
    protected virtual void Update()
    {
        var xmove = Input.GetAxis("Horizontal");

        if (xmove != 0)
            Move(Mathf.CeilToInt(xmove));

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            Interact();
        }
    }

    void Interact()
    {
        if (Interactions.NearTeleport != null)
        {
            Interactions.NearTeleport.Activate(gameObject);
        }
        else if (Interactions.NearNPC != null) {
            Interactions.NearNPC.Say();
        }
        else if (Interactions.NearLadder)
        {
            Climb();
        }
    }

    public void Move(float input)
    {
        int normalizedmove = (input > 0) ? 1 : -1;
        Move(direction: normalizedmove);
    }

    void Activate()
    {

    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Exit")
        {
            LevelController.Global.OnVictory();
        }
    }

    public void Die()
    {
        OnDeath.Invoke();
    }
}