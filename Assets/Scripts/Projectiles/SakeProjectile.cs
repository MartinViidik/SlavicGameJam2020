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

    private void OnCollisionEnter2D(Collision2D other) {
        var enemyController = other.gameObject.GetComponent<EnemyController>();
        if (enemyController) {
            enemyController.OnHit();
        }
        Destroy(gameObject);
            if (other.gameObject.GetComponent<PlayerController>()){
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }

}