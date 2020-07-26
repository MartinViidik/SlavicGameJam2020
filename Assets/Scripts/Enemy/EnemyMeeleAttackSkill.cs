using System.Collections;
using UnityEngine;

namespace Enemy {

    public class EnemyMeeleAttackSkill : MonoBehaviour {

        private bool cooldown;
        private PlayerStats playerStats;

        private void Awake() {
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }

        void FixedUpdate() {
            if (!(GetDistanceToPlayer() < 1) || cooldown) return;
            playerStats.ModifyHealth(-10);
            StartCoroutine("Cooldown");
        }
        

        private float GetDistanceToPlayer() {
            return Vector2.Distance(transform.position, playerStats.transform.position);
        }

        private IEnumerator Cooldown() {
            cooldown = true;
            yield return new WaitForSeconds(2f);
            cooldown = false;
        }

    }

}