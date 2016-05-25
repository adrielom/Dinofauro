using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {
    [SerializeField]
    string gameID; 
    public int maxValue;
    int a;

    void Awake () {
        a = Random.Range (0, maxValue);
        print ("----------------------------------------------------------------" + a);
        Advertisement.Initialize (gameID, true);
    }


    void Update () {
        ShowAd ();
    }

    public void ShowAd (string zone = "") {

        if (string.Equals (zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions ();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.isReady (zone) && (UIWordManager.gO == 1)) {
            RandomizeAds (zone, options);

        }
    }

    void AdCallbackhandler (ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
            UIWordManager.gO = 3;
            break;
            case ShowResult.Skipped:
            UIWordManager.gO = 3;
            break;
            case ShowResult.Failed:
            UIWordManager.gO = 3;
            break;
        }
    }

  
    public void RandomizeAds (string zone, ShowOptions options) {   
        if (a == 1) { 
            Advertisement.Show (zone, options);   
        }
    }

}