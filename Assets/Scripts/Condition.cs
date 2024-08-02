using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    public Stars stars;
    [SerializeField] GameObject sprites;

    public GameObject obj;
    [SerializeField] DestinationTrigger dest;

    void Update()
    {
        // Check if both destinations are successful
        if (dest.GetSuccess())
        {
            Debug.Log("Level Complete");
            ShowStars();
            sprites.SetActive(false);
            obj.SetActive(true);
        }
    }

    void ShowStars()
    {
        int number = stars.GetStars();
        Debug.Log("Stars: " + number);

        oneStar.SetActive(number == 1);
        twoStar.SetActive(number == 2);
        threeStar.SetActive(number == 3);
    }
}
