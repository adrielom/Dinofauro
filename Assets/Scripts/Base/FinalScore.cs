using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    public Text finalScore;
    public Text highScoreMsg;

    AudioSource audioS;

    public AudioClip highScoreMusic, failedMusic;

	// Use this for initialization
	void Start () {

        audioS = GetComponent<AudioSource> ();

        if (Score.score == 0) {
            finalScore.text = "Vofê não comflefou nafa...";
        } else if (Score.score == 1) {
            finalScore.text = "Vofê comflefou " + Score.score + " palafra.";
        } else if (Score.score >= 2) {
            finalScore.text = "Vofê comflefou " + Score.score + " palafras!";
        }

        Score.highScore = PlayerPrefs.GetInt ("High Score");

        if (Score.score > Score.highScore) {
            Score.highScore = Score.score;
            PlayerPrefs.SetInt ("High Score", Score.highScore);
            highScoreMsg.text = "Nofo recorfe!";
            audioS.clip = highScoreMusic;
            audioS.Play ();
        } else {
            highScoreMsg.text = "Fuu";
            audioS.clip = failedMusic;
            audioS.Play ();
        }

	}
	

}
