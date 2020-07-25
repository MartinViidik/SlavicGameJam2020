using UnityEngine;
using UnityEngine.UI;

public class SakeUI : MonoBehaviour
{
    [SerializeField]
    private Image sakeFill;

    private static SakeUI _instance;

    public static SakeUI Instance { get { return _instance; } }

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

        UpdateSakeFill(100);
    }

    public void UpdateSakeFill(float amount)
    {
        sakeFill.fillAmount = amount / 100;
        Debug.Log(sakeFill.fillAmount);
    }

}
