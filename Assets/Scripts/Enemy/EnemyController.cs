using Pathfinding;
using System.Collections;
using UnityEngine;

namespace Enemy {

    public class EnemyController : MonoBehaviour {

        public AIPath aiPath;
        public Animator animator;
        public AIDestinationSetter setter;
        private static readonly int MovementX = Animator.StringToHash("movementX");
        private static readonly int MovementY = Animator.StringToHash("movementY");
        private static readonly int Speed = Animator.StringToHash("speed");

        private GameObject player;
        private bool cooldown = false;

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            setter.target = player.transform;
            StartCoroutine("Cooldown");
        }

        void FixedUpdate() {
            var desiredVelocity = aiPath.desiredVelocity;

            if (!IsStanding(desiredVelocity)) {
                animator.SetFloat(MovementX, desiredVelocity.x);
                animator.SetFloat(MovementY, desiredVelocity.y);
            }

            animator.SetFloat(Speed, desiredVelocity.magnitude);
            if(GetDistanceToPlayer() < 1 && !cooldown)
            {
                player.GetComponent<PlayerStats>().ModifyHealth(-10);
                cooldown = true;
            }
        }

        public void OnHit(int value = 0) {
            Destroy(gameObject);
        }

        private static bool IsStanding(Vector3 desiredVelocity) {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return desiredVelocity.x == 0 &&
                   // ReSharper disable once CompareOfFloatsByEqualityOperator        
                   desiredVelocity.y == 0;
        }

        float GetDistanceToPlayer()
        {
            return Vector2.Distance(transform.position, player.transform.position);
        }

        private IEnumerator Cooldown()
        {
            while (cooldown)
            {
                yield return new WaitForSeconds(1f);
                cooldown = false;
            }
        }

    }

}