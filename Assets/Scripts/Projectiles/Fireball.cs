using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Projectiles {

    public class Fireball : MonoBehaviour {

        public List<AudioClip> fireballFireSound;
        public List<AudioClip> fireballHitSound;

        private const float FireballSpeed = 1.5f;

        private void Awake() {
            Destroy(gameObject, 3f);
            RotateTowardsAndFire(GameObject.FindGameObjectWithTag("Player").transform.position);
            SoundManager.PlaySoundFromList(fireballFireSound);
        }

        private void RotateTowardsAndFire(Vector3 target) {
            var diff = target - transform.position;
            diff.Normalize();
            var rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
            GetComponent<Rigidbody2D>().AddForce(transform.up * FireballSpeed, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other) {
            var playerStats = other.gameObject.GetComponent<PlayerStats>();
            Destroy(gameObject);
            SoundManager.PlaySoundFromList(fireballHitSound);
            if (!playerStats) return;
            playerStats.ModifyHealth(-20);

        }

    }

}