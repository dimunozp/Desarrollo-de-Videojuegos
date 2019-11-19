﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*[SerializeField] to see the variable in unity*/ 

    // Start variables
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Collider2D coll;
    protected bool crunch;
    protected bool punch;
    //FSM
    protected enum State {idle,running,jumping,falling,crunch,punch};
    protected State state = State.idle;

    //Inspector Variables
    [SerializeField] protected LayerMask floor;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float jumpForce = 7f;

    // Start is called before the first frame updateasas
    void Start()
    {
        crunch = false;
        punch = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
        AnimationState();
        animator.SetInteger("state", (int)state);//set animation based on Enumerator state

    }

    virtual public void Movement()
    {
    }

    virtual public void Attack()
    {

    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }

        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(floor))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 1f)
        {
            //Moving
            state = State.running;
        }
        else if (crunch)
        {
            state = State.crunch;
        }
        else if (state == State.punch)
        {
            if (punch)
            {
                punch = false;
            }
        }
        else
        {
            state = State.idle;
        }

    }
}
