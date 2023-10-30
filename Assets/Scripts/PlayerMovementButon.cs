using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementButon : MonoBehaviour
{
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private PlayerControl controls;

    [SerializeField] private LayerMask jumpableGround;

    float dirX = 0f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 14f;

    private enum MovementState { idle, run, jump, fall }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        controls = new PlayerControl();

    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            dirX = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Land.Move.performed -= ctx =>
        {
            dirX = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed -= ctx => Jump();

    }

    private void Update()
    {
        MovementPlayer();
        UpdateAnimationState();
        ChangeVolume();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void MovementPlayer()
    {
        if (dirX<0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                
            }
            else
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (dirX>0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            dirX = 0;
        }
    }


    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
     
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;

        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;

          
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;

        }
        anim.SetInteger("state", (int)state);
    }
    public bool IsGrounded()
    {
        
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }

    private void Jump()
    {
        
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<SFXPlayer>().PlayJump();
        }
         
    }
    private void ChangeVolume()
    {
        if(IsGrounded()) { FindObjectOfType<SFXPlayer>().audioSourceForFootSteps.volume = 5f; }
        if(!IsGrounded()) { FindObjectOfType<SFXPlayer>().audioSourceForFootSteps.volume = 0f; }
    }


    


}
