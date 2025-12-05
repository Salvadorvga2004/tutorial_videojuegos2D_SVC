using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 3;
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 2f;

    string animationState = "AnimationState";

    private bool isPushing = false;

    private enum CharStates
    {
        Pancho = 0,
        WalkPancho = 1,
        RunPancho = 2,
        PushPancho = 3,
        JumpNorth = 4
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float moveInput = 0f;

        // Movimiento lateral
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            rb2D.velocity = new Vector2(movementSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            rb2D.velocity = new Vector2(-movementSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        // CAMBIAR ANIMACIÓN según estado
        if (CheckGround.isGrounded)
        {
            if (isPushing) 
            {
                ChangeAnimationState(CharStates.PushPancho);
            }
            else if (Mathf.Abs(moveInput) > 0.1f)
            {
                ChangeAnimationState(CharStates.WalkPancho);
            }
            else
            {
                ChangeAnimationState(CharStates.Pancho);
            }
        }

        // Saltar
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            ChangeAnimationState(CharStates.JumpNorth);
        }

        // Salto mejorado
        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    void Update()
    {
        // Si está cayendo
        if (!CheckGround.isGrounded && rb2D.velocity.y < 0)
        {
            ChangeAnimationState(CharStates.JumpNorth);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            isPushing = true;
            ChangeAnimationState(CharStates.PushPancho);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            isPushing = false;
        }
    }

    void ChangeAnimationState(CharStates newState)
    {
        animator.SetInteger(animationState, (int)newState);
    }

}
