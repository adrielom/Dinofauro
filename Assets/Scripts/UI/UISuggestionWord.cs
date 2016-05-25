using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UISuggestionWord : MonoBehaviour {

    public int index;
    public Text letraDeEscolha;

    public void SugerirLetra () {
        UIWordManager.Instance.ClickSuggestion (letraDeEscolha.text [0]);
    }

    protected void Click(object sender, EventArgs e)
    {
        UIWordManager.Instance.ClickSuggestion(letraDeEscolha.text[0]);
    }

    public void SetWord(char c)
    {
        letraDeEscolha.text = c.ToString();
    }
}
