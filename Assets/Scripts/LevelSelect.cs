using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public void Levels(int level_num)
    {

        SceneManager.LoadScene(level_num);
        Stars.ResetMistakes();
    }
}
