
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoIngCond : MonoBehaviour
{
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    public Stars stars;
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
            Debug.Log("Level Complete");
            StartCoroutine(levelComplete());
        }
    }
    IEnumerator levelComplete()
    {
        yield return new WaitForSeconds(delay);
        ShowStars();
        sprites.SetActive(false);
        obj.SetActive(true);
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
