/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        // Debug.Log("condition" + dest.GetSuccess());
        if (dest.GetSuccess() && dest2.GetSuccess())
        {
            Debug.Log("here");
            ShowStars();
            sprites.SetActive(false);
            obj.SetActive(true);
        }


    }
    void ShowStars()
    {
        Debug.Log("2");
        int number = stars.GetStars();
        if (number > 1)
        {
            if (number == 3)
            {
                threeStar.SetActive(true);
                twoStar.SetActive(false);
                oneStar.SetActive(false);

            }
            else
            {
                threeStar.SetActive(false);
                twoStar.SetActive(true);
                oneStar.SetActive(false);
            }
        }
        else
        {
            threeStar.SetActive(false);
            twoStar.SetActive(false);
            oneStar.SetActive(true);
        }
    }

}*/
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

    void Update()
    {
        // Check if both destinations are successful
        if (dest.GetSuccess() && dest2.GetSuccess())
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
