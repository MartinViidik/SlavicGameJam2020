using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy {

    public class EnemyFloater : MonoBehaviour {

        private double frequency = 3;
        private double magnitude = 0.1;
        private double sinRandom = 0.1;

        private void Awake() {
            sinRandom = Random.Range(0f, 2f);
        }

        void FixedUpdate() {
            var tf = transform;
            var position = tf.up * (float) (Math.Sin(Time.time * frequency + sinRandom) * magnitude);
            transform.localPosition = position;
        }

    }

}