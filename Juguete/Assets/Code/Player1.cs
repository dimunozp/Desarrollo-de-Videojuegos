﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerController
{
    override public void Movement()
    {
        if (Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.W) && coll.IsTouchingLayers(floor) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && coll.IsTouchingLayers(floor))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
            jump = true;

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Moving Rigth
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //Jump
        else if (Input.GetKeyDown(KeyCode.W) && coll.IsTouchingLayers(floor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
            jump = true;
        }
        //Crunch
        else if (Input.GetKey(KeyCode.S) && coll.IsTouchingLayers(floor))
        {
            crunch = true;
        }
        //Stop Moving
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            crunch = false;
        }
    }
    
    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G) && coll.IsTouchingLayers(floor))
        {
            state = State.punch;
            punch = true;
        }
        if (Input.GetKeyDown(KeyCode.H) && coll.IsTouchingLayers(floor))
        {
            state = State.kick;
            kick = true;
        }

    }
}