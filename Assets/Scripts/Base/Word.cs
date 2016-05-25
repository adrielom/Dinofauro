using UnityEngine;
using System.Collections;

public class Word  {

    private string normalWord;
    private string dinofauroWord;
    private string audioPath;
    private string imagePath;

    public string NormalWord
    {
        get { return normalWord; }
        set { normalWord = value; }
    }

    public string DinofauroWord
    {
        get { return dinofauroWord; }
        set { dinofauroWord = value; }
    }

    public string AudioPath
    {
        get { return audioPath; }
        set { audioPath = value; }
    }

    public string ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }
}
