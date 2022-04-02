using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Player;
using Game_2DPuzzle.Game.Managers;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
	public class Statue : EventProp {
		private void Start() {
			enabled = false;
		}

		public override void OnInteract(PlayerInventory inventory) {
			if (!isUsed) {
				isUsed = true;
				speech.ShowMessage("석상을 가만히 바라보니 기분이 되게 신성해진 것 같습니다...!");

				StartCoroutine(StatueItemDrop(inventory));
			}
			else {
				speech.ShowMessage("어떤 종교가 사용했던 석상인 것 같습니다.");
			}
		}

		IEnumerator StatueItemDrop(PlayerInventory inventory) {
			yield return new WaitForSeconds(5f);

			inventory.GiveItem(giveItem);
			speech.ShowMessage("석상이 떨어트린 아이템 '" + giveItem.GetName() + "'(을)를 획득하였습니다!");
		}
	}
}