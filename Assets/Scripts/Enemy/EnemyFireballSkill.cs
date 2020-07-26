using System.Collections;
using UnityEngine;

namespace Enemy {

    public class EnemyFireballSkill : MonoBehaviour {

        public GameObject fireballPrefab;
        public Transform aimBot;

        private bool cooldown;
        private GameObject player;

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void FixedUpdate() {
            if (!(GetDistanceToPlayer() < 3) || cooldown) return;
            Instantiate(fireballPrefab, aimBot.position, Quaternion.identity);
            StartCoroutine("Cooldown");

        }

        private float GetDistanceToPlayer() {
            return Vector2.Distance(transform.position, player.transform.position);
        }

        private IEnumerator Cooldown() {
            cooldown = true;
            yield return new WaitForSeconds(2f);
            cooldown = false;
        }

    }

}