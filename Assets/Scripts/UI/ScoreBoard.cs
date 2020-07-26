using UnityEngine;
using UnityEngine.UI;

namespace UI {

    public class ScoreBoard : MonoBehaviour {

        public static ScoreBoard Instance { get; private set; }

        public Text scoreText;
        private int points = 0;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            }
            else {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void AddScore(int score) {
            points += score;
            scoreText.text = "Score: " + points;
        }

    }

}