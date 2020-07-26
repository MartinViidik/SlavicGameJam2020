using UnityEngine;
using Utility;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerStats stats;

    public AudioClip pickupSakeSound;
    
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.CompareTag("SakeSupplies")) return;
        stats.StartCoroutine("Cooldown", 1);
        stats.ModifyHealth(100);
        Destroy(collision.gameObject);
        SoundManager.PlaySound(pickupSakeSound);
    }
}
