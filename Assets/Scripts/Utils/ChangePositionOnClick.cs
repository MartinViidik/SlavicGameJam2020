using System.Collections.Generic;
using UnityEngine;

namespace Utils {

    public class ChangePositionOnClick : MonoBehaviour {

        private void Update() {
            if (!Input.GetMouseButtonDown(0)) return;
            var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            transform.position = newPos;
        }

    }

}