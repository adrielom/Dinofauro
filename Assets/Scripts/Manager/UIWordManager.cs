using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class SFX {
    public AudioClip buttonSFX, wrongSFX;
}

public class UIWordManager : MonoBehaviour {

    public static int gO;

    public GameObject wordPrefab;
    public GameObject rootWords;

    public List<UISuggestionWord> suggestionWords;
    public static UIWordManager Instance;
    MemeManager memeM;

    private Word currentWord;
    private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string sWord = "";
    private AudioSource audio;
    public AudioSource sfx;
    public SFX soundEffects;

    public Text timeCounter;
    public Image fillTimeBar;
    public float timeBarSpeed = 13.5f;
    public Text extraTime;    
    public float startingTime = 60f;
    private float currentTime = 0f;
    public float timeBonus = 5f;
    bool addedFirst;

    public Text errors;
    public int maxErrors = 5;
    private int currentErrors = 0;
    public GameObject lifeCounter;

    public Image helpSprite;

    // Use this for initialization
	void Start () {
        gO = 0;
        Instance = this;
        memeM = GameObject.Find("_Game Manager").GetComponent<MemeManager>();
        extraTime.rectTransform.sizeDelta = new Vector2 (0, 0);
        audio = GetComponent<AudioSource>();
        StartCoroutine(LoadWords());
        currentTime = startingTime;
        currentErrors = maxErrors;

	}
	
	// Update is called once per frame
	void Update () {
        CheckVictory ();

        currentTime -= Time.deltaTime;
        timeCounter.text = ((int)currentTime).ToString ();
        errors.text = currentErrors.ToString () + " TENTATIVAS";

        if (extraTime.rectTransform.sizeDelta.x <= 160 && addedFirst) {
            extraTime.rectTransform.sizeDelta += new Vector2 (1f, 1f);
        }

	}

    IEnumerator LoadWords()
    {
        while (WordManager.Instance == null || !WordManager.Instance.IsLoadComplete)
            yield return new WaitForSeconds(0);

        RefreshUI(WordManager.Instance.GetRandomWord());
        RefreshUISugestion();
    }

    public void RefreshUI(Word newWord)
    {
        this.currentWord = newWord;
        sWord = currentWord.NormalWord;
        audio.clip = Resources.Load<AudioClip>(currentWord.AudioPath);
        helpSprite.sprite = Resources.Load<Sprite> (currentWord.ImagePath);

        audio.Play();
        print(currentWord.NormalWord);
        int length = currentWord.NormalWord.Length;
        
        for (int i = 0; i < rootWords.transform.childCount; i++)
        {
            Destroy(rootWords.transform.GetChild(i).gameObject);
        }        

        for (int i = 0; i < length; i++)
        {
            GameObject obj = Instantiate(wordPrefab) as GameObject;
            obj.transform.SetParent (rootWords.transform, false);
        }

    }

    private void RefreshUISugestion()
    {

        int firstIndexRandom = 0;
        int secondIndexRandom = 0;

        if (sWord.Length > 1)
        {
            firstIndexRandom = Random.Range(0, suggestionWords.Count);            
            do
            {
                secondIndexRandom = Random.Range(0, suggestionWords.Count);
            } while (secondIndexRandom == firstIndexRandom);

            int firstWordIndexRandom = Random.Range(0, sWord.Length);
            int secondWordIndexRandom = 0;
            do
            {
                secondWordIndexRandom = Random.Range(0, sWord.Length);
            } while (secondWordIndexRandom == firstWordIndexRandom);


            UISuggestionWord word = suggestionWords[firstIndexRandom];
            word.SetWord(sWord[firstWordIndexRandom]);

            UISuggestionWord secWord = suggestionWords[secondIndexRandom];
            secWord.SetWord(sWord[secondWordIndexRandom]);



            for (int i = 0; i < suggestionWords.Count; i++)
            {
                if (i != firstIndexRandom && i != secondIndexRandom)
                {
                    string c = "a";
                    do
                    {
                        int num = Random.Range(0, chars.Length);
                        c = chars[num].ToString();
                    } while (suggestionWords.Find(x => x.letraDeEscolha.text == c) != null);
                    suggestionWords[i].SetWord(c[0]);
                }
            }


        }
        else 
        {
            firstIndexRandom = Random.Range(0, suggestionWords.Count);
            int firstWordIndexRandom = Random.Range(0, sWord.Length);

            UISuggestionWord word = suggestionWords[firstIndexRandom];
            word.SetWord(sWord[firstWordIndexRandom]);

            for (int i = 0; i < suggestionWords.Count; i++)
            {
                if (i != firstIndexRandom )
                {
                    string c = "a";
                    do
                    {
                        int num = Random.Range(0, chars.Length);
                        c = chars[num].ToString();
                    } while (suggestionWords.Find(x => x.letraDeEscolha.text == c) != null);
                    suggestionWords[i].SetWord(c[0]);
                }
            }
        }
    }

    public void ClickSuggestion(char c)
    {
        if (sWord.Contains(c.ToString()))
        {
            sWord = sWord.Replace(c.ToString(),"");
            print(sWord);
            for (int i = 0; i < currentWord.NormalWord.Length; i++)
            {
                if (currentWord.NormalWord[i] == c)
                {
                    rootWords.transform.GetChild(i).GetComponent<UIWord>().SetWord(c);    
                    
                } 
            }
            sfx.clip = soundEffects.buttonSFX;
            sfx.Play ();
        } else {
            currentErrors--;
            lifeCounter.transform.GetChild (currentErrors).gameObject.SetActive (false);
            sfx.clip = soundEffects.wrongSFX;
            sfx.Play ();
        }

        if (sWord.Length == 0) {
            Score.score++;
            extraTime.text = "+" + ((int)currentWord.NormalWord.Length + 1).ToString ();
            currentTime += (int)currentWord.NormalWord.Length + 1;
            if (currentTime > startingTime) currentTime = startingTime;
            ExtraTimer ();
            RefreshUI (WordManager.Instance.GetRandomWord ());
            memeM.CancelHelp ();
        }           
        RefreshUISugestion();
    }

    void ExtraTimer () {
        fillTimeBar.rectTransform.sizeDelta -= new Vector2 (timeBarSpeed * ((int)currentWord.NormalWord.Length + 1), 0f);
        if (fillTimeBar.rectTransform.sizeDelta.x <= 0) fillTimeBar.rectTransform.sizeDelta = new Vector2 (0, fillTimeBar.rectTransform.sizeDelta.y);
        addedFirst = true;
        extraTime.CrossFadeAlpha (1f, 0f, false);
        extraTime.CrossFadeAlpha (0f, 2f, false);
        extraTime.rectTransform.sizeDelta = new Vector2(20f, 20f);
    }

    void CheckVictory () {
        if (currentErrors <= 0 || currentTime <= 0f) {
            Application.LoadLevel ("Game Over");
            gO = 1;
        }
    }



}
