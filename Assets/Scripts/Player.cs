using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [SerializeField] private float runSpeed = 5f;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        
    }

    private void Run() {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = playerVelocity;
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x),1f);
        }
    }
}
