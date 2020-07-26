using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
    private GameObject pauseScreen;
    private static UIController _instance;
    public static UIController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        EnableDeathScreen(false);
    }

    public void EnableDeathScreen(bool state)
    {
        deathScreen.SetActive(state);
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        AudioListener.volume = 0;
    }

}
