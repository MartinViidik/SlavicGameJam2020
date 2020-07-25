using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text jap;

    [SerializeField]
    private TMP_Text eng;

    [SerializeField]
    private string[] jap_proverb;

    [SerializeField]
    private string[] eng_proverb;

    [SerializeField]
    private GameObject ingameUI;

    private static DeathScreen _instance;

    public static DeathScreen Instance { get { return _instance; } }

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

    }

    private void OnEnable()
    {
        int RNG = Random.Range(0, jap_proverb.Length);
        jap.text = jap_proverb[RNG];
        eng.text = eng_proverb[RNG];
        ingameUI.SetActive(false);
    }

}
