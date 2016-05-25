using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour {

    public Text mainHighScore;

	// Use this for initialization
	void Start () {
        mainHighScore.text = "Fontuação Máfima: " + PlayerPrefs.GetInt ("High Score");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
