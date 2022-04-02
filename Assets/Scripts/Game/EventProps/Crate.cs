using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.UI;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
	public class Crate : MonoBehaviour {
		[SerializeField]
		private Speech speech;

		[SerializeField]
		private GameObject targetObject;

		private void OnTriggerEnter2D(Collider2D collision) {
			Debug.Log(collision.gameObject.name);

			if (collision.gameObject.name.Contains("Crate")) {
				if (targetObject.GetComponent<EventProp>() != null) {
					targetObject.GetComponent<EventProp>().enabled = true;
					speech.ShowMessage("상자를 특정 위치로 옮겼더니 석상이 조금 움직인 것 같습니다...!");
				}
			}
		}
	}
}