using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public Slider music_slider;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ChangeVolume()
    {
        AudioManager.Instance.ChangeVolume(music_slider.value);
    }
}
