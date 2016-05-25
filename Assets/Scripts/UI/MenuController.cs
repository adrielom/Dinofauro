using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

    AudioSource audio;
    public GameObject loadingScreen;

    void Start () {
        if (!PlayerPrefs.HasKey("Played First")) {
            PlayerPrefs.SetInt ("Played First", 0);
        }

        audio = GameObject.Find ("_Game Manager").GetComponent<AudioSource> ();

        WordManager [] managers = GameObject.FindObjectsOfType<WordManager> ();
        for (int i = 0; i < managers.Length; i++) {
            Destroy (managers [i].gameObject);
        }
    }

    public void StartGame(){
        audio.Play ();
        loadingScreen.SetActive (true);
        Application.LoadLevel ("Forca");        
    }
   
    public void StartGameWithTutorial () {
        if (PlayerPrefs.GetInt("Played First") == 1) {
            StartGame ();
        } else {
            audio.Play ();
            Application.LoadLevel ("Tutorial Screen");
        }
    }

    public void StartTutorial () {
        Application.LoadLevel ("Tutorial Screen");
    }

	public void Quit(){
        audio.Play ();
        Application.Quit ();
    }

	public void MenuInicial (){
        audio.Play ();
        Application.LoadLevel ("MenuPrincipal");
	}

}
