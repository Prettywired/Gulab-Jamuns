using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLevels : MonoBehaviour
{
    public GameObject gameObject;
    public Button[] buttons;
    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void Levels(int level_num)
    {

        SceneManager.LoadScene(level_num);
        Stars.ResetMistakes();
    }
    private void ButtonsToArray()
    {
        int childCount = gameObject.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}

