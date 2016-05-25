using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWord : MonoBehaviour {

    public Text text;

    public void SetWord(char word)
    {
        text.text = word.ToString();
    }
}
