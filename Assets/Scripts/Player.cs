using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    
    //Config
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    
    //State
    private bool isAlive = true;
    
    //Cached componet references
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Collider2D collider2D;
    private float gravityScaleAtStart;
    
    //Messages then Methods
    // Start is called before the first frame update
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        gravityScaleAtStart = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
        
    }

    private void Run() {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void ClimbLadder() {

        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"))) {
            animator.SetBool("Climbing",false);
            rigidbody2D.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlFlow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rigidbody2D.velocity.x, controlFlow * climbSpeed);
        rigidbody2D.velocity = climbVelocity;
        rigidbody2D.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climbing",playerHasVerticalSpeed);
    }

    private void Jump() {
        if(!collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        
        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            Vector2 jumpVelocityToAdd = new Vector2(0,jumpSpeed);
            rigidbody2D.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x),1f);
        }
    }
}
