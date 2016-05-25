using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialLoader : MonoBehaviour {

    public GameObject tutorialButton;
    public GameObject loadingScreen;

    public GameObject playButton, backButton;

    public Sprite [] tutorials;
    public Image tutorialPanel;
    public int index;

    void Start () {
        tutorialPanel.sprite = tutorials [0];
        index = 0;
    }

	public void nextIndex () {
        if(index < tutorials.Length - 1) {
            index++;
            tutorialPanel.sprite = tutorials [index];
        }
        
        if (index == tutorials.Length - 1) {
            playButton.SetActive (true);
            backButton.SetActive (true);
        }     
    }

    public void GoToGame () {
        if(PlayerPrefs.HasKey("Played First")) {
            if (PlayerPrefs.GetInt("Played First") == 0) {
                PlayerPrefs.SetInt ("Played First", 1);
            }
        }

        loadingScreen.SetActive (true);
        Application.LoadLevel ("Forca");
    }

    public void BackToMenu () {
        Application.LoadLevel ("MenuPrincipal");
    }
}
