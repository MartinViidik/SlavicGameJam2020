using Enemy;
using UnityEngine;

public class SakeProjectile : MonoBehaviour {

    [SerializeField] private GameObject SakeVisual;
    private float rotationModifier;

    private void Awake() {
        Destroy(gameObject, 2f);
        rotationModifier = Random.Range(1, 3);
    }

    private void Update() {
        transform.Rotate(0, 0, (120 * rotationModifier) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyController = collision.gameObject.GetComponent<EnemyController>();
        if (enemyController)
        {
            enemyController.OnHit();
        }
        if(collision.gameObject.tag != "Player" || collision.gameObject.tag == "SakeSupplies")
        {
            Destroy(gameObject);
        }
    }

}