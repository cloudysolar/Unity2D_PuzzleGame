using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Managers;
using Game_2DPuzzle.Game.Player;
using Game_2DPuzzle.Game.UI;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
    public class Chest : EventProp {
        [SerializeField]
        private Sprite[] images = new Sprite[2]; // 0 = 닫힌 상자 / 1 = 열린 상자

        private SpriteRenderer render;

		private void Start() {
            render = GetComponent<SpriteRenderer>();
		}

		public override void OnInteract(PlayerInventory inventory) {
            // Debug.Log("Chest 상호작용 실행!");

            if (!isUsed) {
                isUsed = true;
                StartCoroutine("OpenAndClose");

                inventory.GiveItem(giveItem);
                speech.ShowMessage("아이템 '" + giveItem.GetName() + "'(을)를 획득하였습니다!");
            }
        }

        IEnumerator OpenAndClose() {
            render.sprite = images[1];

            yield return new WaitForSeconds(1f);

            render.sprite = images[0];
        }
    }
}