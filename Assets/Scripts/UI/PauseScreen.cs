using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1.0f;
        AudioListener.volume = 1;
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        AudioListener.volume = 1;
        LevelChanger.Instance.LoadLevel(0);
    }
}
