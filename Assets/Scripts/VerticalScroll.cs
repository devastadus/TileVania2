﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip("Game Units per second")]
    [SerializeField] private float scrollRate = .2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0,yMove));
        
    }
}
