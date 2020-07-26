using System;
using UnityEngine;

namespace Enemy {

    public class EnemyFloater : MonoBehaviour {

        private double frequency = 3;
        private double magnitude = 0.3;

        void FixedUpdate() {
            var tf = transform;
            var position = tf.up * (float) (Math.Sin(Time.time * frequency) * magnitude);
            transform.localPosition = position;
        }

    }

}