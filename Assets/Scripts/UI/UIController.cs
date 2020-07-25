using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject deathScreen;
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

}
