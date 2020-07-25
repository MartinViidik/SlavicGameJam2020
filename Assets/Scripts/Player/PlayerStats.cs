using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float playerHealth = 100;

    [SerializeField]
    int playerAmmo = 5;

    private PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
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

        Debug.Log("Player health at: " + playerHealth);

        if(playerHealth == 0)
        {
            player.SetLiveStatus(false);
        }
    }

    public bool hasAmmo()
    {
        if(playerAmmo > 0)
        {
            return true;
        } else {
            return false;
        }
    }
    public void SetAmmo(int amount)
    {
        playerAmmo += amount;
    }

}
