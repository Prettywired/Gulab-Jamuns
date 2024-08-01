using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Condition : MonoBehaviour
{
    [SerializeField] GameObject oneStar;
    [SerializeField] GameObject twoStar;
    [SerializeField] GameObject threeStar;
    [SerializeField] GameObject sprites;
    public Stars stars;
    public GameObject obj;
    [SerializeField] DestinationTrigger dest;

    void Update()
    {

        if (dest.GetSuccess())
        {
            ShowStars();

            sprites.SetActive(false);
            obj.SetActive(true);
        }
    }
    void ShowStars()
    {
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

}
