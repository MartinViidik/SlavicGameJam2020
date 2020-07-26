using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject About;
    private void Awake()
    {
        ShowMenu();
    }
    public void StartGame()
    {
        LevelChanger.Instance.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
        About.SetActive(false);
    }

    public void ShowAbout()
    {
        Menu.SetActive(false);
        About.SetActive(true);
    }

}
