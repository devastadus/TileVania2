using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
    [SerializeField] private AudioClip coinPickupSFX;

    [SerializeField] private int pointsForCoinPickup = 100;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        AudioSource.PlayClipAtPoint(coinPickupSFX,Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        Destroy(gameObject);
    }
}
