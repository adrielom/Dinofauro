using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

        float _fps = 1.0f / Time.deltaTime;
        text.text = _fps.ToString ();

	}
}
