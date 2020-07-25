using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerStats stats;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SakeSupplies"))
        {
            stats.StartCoroutine("Cooldown", 1);
            stats.ModifyHealth(100);
            Destroy(collision.gameObject);
        }
    }
}
