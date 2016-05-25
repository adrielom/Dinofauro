using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

    public bool isSplashEnded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (isSplashEnded) {
            Application.LoadLevel ("MenuPrincipal");
        }

	}

}
