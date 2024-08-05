
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwoIngCond : MonoBehaviour
{
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    [SerializeField] GameObject sprites;

    public GameObject obj;
    [SerializeField] DestinationTrigger dest;
    [SerializeField] DestinationTrigger dest2;
    float delay = 2f;

    void Update()
    {
        // Check if both destinations are successful
        if (dest.GetSuccess() && dest2.GetSuccess())
        {
            unlockLevel();
            StartCoroutine(LevelComplete());
        }
    }
    public void unlockLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Reached Index"))
        {
            PlayerPrefs.SetInt("Reached Index", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Unlocked Level", PlayerPrefs.GetInt("Unlocked", 1) + 1);
            PlayerPrefs.Save();
        }

    }
    IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(delay);
        ShowStars();
        sprites.SetActive(false);
        obj.SetActive(true);
    }

    void ShowStars()
    {
        int number = Stars.GetStars();
        Debug.Log("Stars: " + number);

        oneStar.SetActive(number == 1);
        twoStar.SetActive(number == 2);
        threeStar.SetActive(number == 3);
    }
}
