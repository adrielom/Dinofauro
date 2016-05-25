using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class WordManager : MonoBehaviour {

    public static WordManager Instance;

    private List<Word> words;
    private bool isLoadComplete;
	// Use this for initialization

    void Awake()
    {
        WordManager[] managers = GameObject.FindObjectsOfType<WordManager>();
        if (managers.Length > 1 && words == null)
            Destroy(gameObject);

    }

	void Start () {
        Instance = this;
        words = new List<Word>();
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadWords());
	
	}

    private IEnumerator LoadWords()
    {
        try
        {
            isLoadComplete = false;
            string line;
            TextAsset file = Resources.Load<TextAsset>("Palavras");
            StringReader reader = new StringReader(file.text);
            while (true)
            {
                line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    string[] split = line.Split(';');
                    Word word = new Word();
                    word.NormalWord = split[0];
                    word.DinofauroWord = split[1];
                    word.AudioPath = "Som/" + word.NormalWord;
                    word.ImagePath = "ImagemDasDicas/" + word.NormalWord;
                    words.Add(word);
                }
                else
                {
                    break;
                }
            }
        }
        catch (System.Exception)
        {
            
            throw;
        }

        isLoadComplete = true;
        yield return new WaitForSeconds(0.0f);
        
    }

    public Word GetRandomWord()
    {
        int index = Random.Range(0, words.Count);
        return words[index];
    }

    public bool IsLoadComplete 
    {
        get { return isLoadComplete; }        
    }

}
