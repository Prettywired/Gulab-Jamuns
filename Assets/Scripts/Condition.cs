using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Condition : MonoBehaviour
{
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    [SerializeField] GameObject sprites;

    public GameObject obj;
    [SerializeField] DestinationTrigger dest;
    public float delay = 2f;

    void Update()
    {
        // Check if both destinations are successful
        if (dest.GetSuccess())
        {
            unlockLevel();
            StartCoroutine(LevelComplete());
        }
    }

    public void unlockLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("Index Reached");
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);
        if (currentLevelIndex >= reachedIndex)
        {
            if (currentLevelIndex == 9)
            {
                Debug.Log("Levels Completed");
            }
            else
            {
                PlayerPrefs.SetInt("Index Reached", currentLevelIndex + 1);
                PlayerPrefs.SetInt("Unlocked Level", unlockedLevel + 1);
                PlayerPrefs.Save();

                Debug.Log("New Reached Index: " + (currentLevelIndex + 1));
                Debug.Log("New Unlocked Level: " + (unlockedLevel + 1));
            }
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
        oneStar.SetActive(number == 1);
        twoStar.SetActive(number == 2);
        threeStar.SetActive(number == 3);
    }
}
