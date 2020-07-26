using UnityEngine;

namespace Utils {

	public class FireballOnMouseClick : MonoBehaviour {

		public GameObject fireballPrefab;

		private void Update() {
			if (!Input.GetMouseButtonDown(0)) return;
			var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = 0;
			Instantiate(fireballPrefab, newPos, Quaternion.identity);
		}

	}

}
