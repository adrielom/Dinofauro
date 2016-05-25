using UnityEngine;
using UnityEngine.Advertisements;

using System.Collections;

public class AdManager : MonoBehaviour {

    [SerializeField]
    string gameID;

    void Awake () {
        Advertisement.Initialize (gameID, true);
    }


    IEnumerator ShowAdWhenReady () {
        while (!Advertisement.isReady () && (Application.loadedLevelName == "Game Over"))
            yield return null;

        Advertisement.Show ();
    }


}