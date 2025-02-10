using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //All component reassigned into variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    //Link to Terrain layer
    [SerializeField] private LayerMask jumpableGround;

    //Variables
    private float dirX = 0f;

    //Costum Variables
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] public float jumpForce = 14f;

    //Animation state
    private enum MovementState { idle, running, jumping, falling }//idle animation, running animation etc.
    private MovementState state = MovementState.idle;//At start is idle

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource trampolineSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        //Getting all components and links.
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement Script horizontal
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Jump script
        if (Input.GetButtonDown("Jump") && IsGrounded())//If button pressed and is on ground using "IsGrounded" method.
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }


        UpdateAnimationState();//Linking to Animation method below

    }

    //Character Animation method
    private void UpdateAnimationState()
    {
        MovementState state;

        //Checking what animation should be used
        if (dirX > 0f)//If horizontal more than 0 speed then running
        {
            state = MovementState.running;//Changing to running
            sprite.flipX = false;
        }
        else if (dirX < 0f)//If horizontal less than zero then moving the other way
        {
            state = MovementState.running;//Changing to running
            sprite.flipX = true;//Flip for other way running
        }
        else
        {
            state = MovementState.idle;//If not running then idle.
        }

        if(rb.velocity.y > 0.1f)//If y velocity higher than 0.1 then jumping.
        {
            state = MovementState.jumping;//Animation change to jumping.
        }
        else if (rb.velocity.y < -.1f)//If y velocity lower than .1 then falling down
        {
            state = MovementState.falling;//Animation change to falling.
        }
        anim.SetInteger("state", (int)state);//uses "state int" in animator tab.
    }
    private bool IsGrounded()
    {
        //Check if player is on the ground using boxcast
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumpForce = 20f;
            trampolineSoundEffect.Play();
        }

        if (collision.gameObject.CompareTag("Super Trampoline"))
        {
            jumpForce = 35f;
        }

        if (collision.gameObject.CompareTag("ultra Trampoline"))
        {
            jumpForce = 27f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jumpForce = 14f;   
    }
}
