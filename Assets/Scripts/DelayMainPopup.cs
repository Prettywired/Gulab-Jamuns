using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayMainPopup : MonoBehaviour
{
    float delay = 2f;
    public GameObject mainMenu;
    public AdManager adManager;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(PopUP());
    }
    IEnumerator PopUP()
    {
        yield return new WaitForSeconds(delay);
        adManager.LoadAd();
        mainMenu.gameObject.SetActive(true);
    }

}
