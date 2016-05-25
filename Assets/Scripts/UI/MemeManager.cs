using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Memes {
    public string memeText;
    public AudioClip memeSounds;
}

public class MemeManager : MonoBehaviour {

    public Memes [] memes;
    public GameObject memeBalloon;
    public Text balloonText;

    public GameObject helpBalloon;    

    [HideInInspector]
    public bool helpOn, canMeme;

    private AudioSource audioS;

    void Start () {
        audioS = GetComponent<AudioSource> ();
        canMeme = true;
    }

	public void MemeTalk () {
        if (!helpOn && canMeme) {
            canMeme = false;
            int index = Random.Range (0, memes.Length);
            balloonText.text = memes [index].memeText;
            audioS.clip = memes [index].memeSounds;
            audioS.Play ();
            memeBalloon.SetActive (true);
            Invoke ("CancelMeme", audioS.clip.length);
        }
    }

    public void ActivateHelp () {
        if (!helpOn) {
            helpOn = true;
            helpBalloon.SetActive (true);
            memeBalloon.SetActive (false);
        }
        
    }

    void CancelMeme () {
        memeBalloon.SetActive (false);
        canMeme = true;
    }

    public void CancelHelp () {
        Debug.Log ("cancel help");
        helpBalloon.SetActive (false);
        helpOn = false;
    }

}
