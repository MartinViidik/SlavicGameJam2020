using UnityEngine;

namespace Projectiles {

    public class Fireball : MonoBehaviour {

        private void Awake() {
            Destroy(gameObject, 3f);
            RotateTowardsAndFire(GameObject.FindGameObjectWithTag("Player").transform.position);
        }

        private void RotateTowardsAndFire(Vector3 target) {
            var diff = target - transform.position;
            diff.Normalize();
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
            GetComponent<Rigidbody2D>().AddForce(transform.up * 3, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            var playerStats = other.gameObject.GetComponent<PlayerStats>();
            Destroy(gameObject);
            if (!playerStats) return;
            playerStats.ModifyHealth(20);
            
        }

    }

}