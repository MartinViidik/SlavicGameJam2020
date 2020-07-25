using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float playerHealth = 100;

    [SerializeField]
    int playerAmmo = 5;

    private PlayerController player;
    private bool cooldownActive = false;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        StartCoroutine("Cooldown", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            ModifyHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            ModifyHealth(-10);
        }
    }
    public void ModifyHealth(int amount)
    {
        playerHealth += amount;
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        SakeUI.Instance.UpdateSakeFill(playerHealth);

        Debug.Log("Player health at: " + playerHealth);

        if(playerHealth == 0)
        {
            player.SetLiveStatus(false);
        }
    }

    public IEnumerator Cooldown(int amount)
    {
        StopCoroutine("SoberUp");
        cooldownActive = true;
        yield return new WaitForSeconds(amount);
        cooldownActive = false;
        StartCoroutine("SoberUp");
    }

    private IEnumerator SoberUp()
    {
        while (!cooldownActive)
        {
            yield return new WaitForSeconds(1f);
            ModifyHealth(-1);
        }
    }

}
