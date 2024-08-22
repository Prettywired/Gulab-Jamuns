using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    float delay = 1f;
    public AdManager adManager;

    void Start()
    {
        adManager.LoadAd();
    }
    public void Levels(int level_num)
    {
        adManager.ShowInterstitialAd();
        StartCoroutine(HandleNext(level_num));


    }
    IEnumerator HandleNext(int level_num)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(level_num);
        Stars.ResetMistakes();
    }
}
