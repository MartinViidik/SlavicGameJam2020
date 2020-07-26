using Pathfinding;
using UnityEngine;

namespace Enemy {

    public class EnemyController : MonoBehaviour {

        public AIPath aiPath;
        public Animator animator;
        public AIDestinationSetter setter;
        private static readonly int MovementX = Animator.StringToHash("movementX");
        private static readonly int MovementY = Animator.StringToHash("movementY");
        private static readonly int Speed = Animator.StringToHash("speed");

        private void Awake() {
            setter.target = GameObject.FindGameObjectWithTag("Player").transform;
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
        }

        private static bool IsStanding(Vector3 desiredVelocity) {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            return desiredVelocity.x == 0 &&
                   // ReSharper disable once CompareOfFloatsByEqualityOperator        
                   desiredVelocity.y == 0;
        }

    }

}