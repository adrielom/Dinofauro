using UnityEngine;
using System.Collections;

public class MenuSwitch : MonoBehaviour {

    public GameObject menuCanvas, creditsCanvas;

    public void BackToMenu () {
        menuCanvas.SetActive (true);
        creditsCanvas.SetActive (false);
    }

    public void GoToCredits () {
        menuCanvas.SetActive (false);
        creditsCanvas.SetActive (true);
    }

}
