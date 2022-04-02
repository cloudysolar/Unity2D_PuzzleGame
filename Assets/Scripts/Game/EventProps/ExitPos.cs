using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_2DPuzzle.Game.EventProps {
    public class ExitPos : MonoBehaviour {
		private void OnTriggerEnter2D(Collider2D collision) {
			if (collision != null && collision.tag == "Player") {
				if (collision is BoxCollider2D) {
					SceneManager.LoadScene(0);
				}
			}
		}
	}
}