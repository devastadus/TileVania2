using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] private int playerLives = 3;
    [SerializeField] private int score = 0;

    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;
    
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();

    }

    public void AddToScore(int pointsToAdd) {
        score += pointsToAdd;
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    public void ProcessPlayerDeath() {
        if (playerLives > 1) {
            TakeLife();
        }
        else {
            ResetGameSession();
        }
    }

    private void TakeLife() {
        --playerLives;
        livesText.text = playerLives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
