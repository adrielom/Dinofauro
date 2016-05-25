using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

	public Image fillbar; // the image for the bar that will decrease the width.
	public float speed; // how many pixels the fill bar will decrease in a second.
	Image fc;

	public Color initialFillColor, lastFillColor;

	void Start(){

		fc = fillbar.GetComponent<Image>();

	}

	// Update is called once per frame
	void Update () {

		updateBar();
	
	}


	void updateBar(){

        fillbar.rectTransform.sizeDelta = new Vector2 (fillbar.rectTransform.sizeDelta.x + Time.deltaTime * speed, fillbar.rectTransform.sizeDelta.y);

        /*if (fillbar.rectTransform.sizeDelta.x <= 0.0f){
            Debug.Log ("working");
			fillbar.rectTransform.sizeDelta = new Vector2(fillbar.rectTransform.sizeDelta.x + Time.deltaTime * speed, fillbar.rectTransform.sizeDelta.y);
			//fc.color = Color.Lerp(fc.color, lastFillColor, Time.deltaTime /(800/speed));

		}*/

	}
}
