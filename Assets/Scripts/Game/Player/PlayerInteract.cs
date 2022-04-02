using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.EventProps;

using UnityEngine;

namespace Game_2DPuzzle.Game.Player {
    public class PlayerInteract : MonoBehaviour {
        // 상호작용 키를 눌렀을 때 상호작용이 가능한 오브젝트가 주변에 있을 경우에는 true
        public bool availableInteract = false;

        [SerializeField]
        private KeyCode interactKey = KeyCode.E;

        private GameObject interactObject;

        private void Update() {
            if (availableInteract & Input.GetKeyDown(interactKey)) {
                PlayerInventory inventory = GetComponent<PlayerInventory>();
                EventProp eventProp = interactObject.GetComponent<EventProp>();

                if (eventProp != null) {
                    if (eventProp.enabled) {
                        eventProp.OnInteract(inventory);
                    }
                    else {
                        Debug.LogWarning("활성화되지 않은 상호작용 오브젝트를 플레이어가 사용했습니다!");
                    }
                }
            }
        }

		private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag == "Interactable") {
                interactObject = collision.gameObject;
                availableInteract = true;
            }
            else if (collision.transform.parent.tag == "Interactable") {
                interactObject = collision.transform.parent.gameObject;
                availableInteract = true;
            }
		}

		private void OnTriggerExit2D(Collider2D collision) {
            if (collision.tag == "Interactable") {
                interactObject = null;
                availableInteract = false;
            }
		}
	}
}