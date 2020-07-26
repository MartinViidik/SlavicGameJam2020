using Pathfinding;
using UI;
using UnityEngine;
using Utility;

namespace Enemy {

    public class EnemyController : MonoBehaviour {

        public AIPath aiPath;
        public Animator animator;
        public AIDestinationSetter setter;

        public AudioClip deathSound;

        public int scoreValue = 10;
        private static readonly int MovementX = Animator.StringToHash("movementX");
        private static readonly int MovementY = Animator.StringToHash("movementY");
        private static readonly int Speed = Animator.StringToHash("speed");

        private GameObject player;
        
        

        private void Awake() {
            player = GameObject.FindGameObjectWithTag("Player");
            setter.target = player.transform;
        }

        void FixedUpdate() {
            var desiredVelocity = aiPath.desiredVelocity;

            if (!IsStanding(desiredVelocity)) {
                animator.SetFloat(MovementX, desiredVelocity.x);
                animator.SetFloat(MovementY, desiredVelocity.y);
            }
            animator.SetFloat(Speed, desiredVelocity.magnitude);

        }

        public void OnHit(int value = 0) {
            Destroy(gameObject);
            ScoreBoard.Instance.AddScore(scoreValue);
            SoundManager.PlaySound(deathSound);
        }

        private static bool IsStanding(Vector3 desiredVelocity) {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return desiredVelocity.x == 0 &&
                   // ReSharper disable once CompareOfFloatsByEqualityOperator        
                   desiredVelocity.y == 0;
        }

    }

}