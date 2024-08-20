using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    float delay = 1f;
    public AdManager adManager;
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        adManager.ShowRewardedAd();
        StartCoroutine(HandleRestart());


    }
    IEnumerator HandleRestart()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Stars.ResetMistakes();
    }


}
