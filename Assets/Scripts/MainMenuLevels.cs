using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLevels : MonoBehaviour
{
    public GameObject buttonContainer; // Rename to clarify its purpose
    public Button[] buttons;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);
        Debug.Log("Unlocked Level on Awake: " + unlockedLevel);

        // Set all buttons to non-interactable
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            Debug.Log("Button " + i + " set to non-interactable");
        }

        // Set buttons up to the unlocked level to be interactable
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = true;
                Debug.Log("Button " + i + " is now interactable");
            }
            else
            {
                Debug.LogWarning("Unlocked Level exceeds button count");
            }
        }
    }
    public void Levels(int level_num)
    {
        SceneManager.LoadScene(level_num);
        Stars.ResetMistakes(); // Ensure this method exists and works as expected
    }

    private void ButtonsToArray()
    {
        int childCount = buttonContainer.transform.childCount;
        buttons = new Button[childCount];
        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = buttonContainer.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
