﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private Rigidbody2D rigidbody2D;
    
    [SerializeField] private float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
        if (IsFacingRight()) {
            rigidbody2D.velocity = new Vector2(moveSpeed,0);
        }
        else {
            rigidbody2D.velocity = new Vector2(-moveSpeed,0);
        }
    }

    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other) {
        transform.localScale = new Vector2(-Mathf.Sign(rigidbody2D.velocity.x),1f);
    }
}
