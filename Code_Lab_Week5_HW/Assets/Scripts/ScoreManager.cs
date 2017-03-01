using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text score;

    private const string PLAYER_PREF_TEST_KEY = "test";

    private const string PREF_HIGHSCORE = "highscorePref";

    private int _score;

    public int Score {
        get {
            return _score;
        }
        set {
            _score = value;

            if(_score > HighScore) {
                HighScore = _score;
            }

            Debug.Log(_score);
        }
    }

    private int _highScore = 3;

    public int HighScore {
        get {
            _highScore = PlayerPrefs.GetInt(PREF_HIGHSCORE, _highScore);
            return _highScore;
        }

        set {
            Debug.Log("Confetti!!!");
            _highScore = value;
            PlayerPrefs.SetInt(PREF_HIGHSCORE, _highScore);
        }
    }

    public static ScoreManager instance;

    public static void SayHi() {
        Debug.Log("Hi!!!");
    }

	// Use this for initialization
	void Start () {
		if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        //PlayerPrefs.SetString(PLAYER_PREF_TEST_KEY, "This is a test");

        //Debug.Log(PlayerPrefs.GetString(PLAYER_PREF_TEST_KEY));

        score.text = "Score: " + Score.ToString();

    }
}
