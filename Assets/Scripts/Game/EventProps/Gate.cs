using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Player;
using Game_2DPuzzle.Game.Managers;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
	public class Gate : EventProp {
		[SerializeField]
		private GameObject gateClosed;

		[SerializeField]
		private GameObject gateOpened;

		[SerializeField]
		private GameObject tileMap;

		private void Start() {
			gateClosed.SetActive(false);
			gateOpened.SetActive(false);
		}

		public override void OnInteract(PlayerInventory inventory) {
			if (!isUsed) {
				if (inventory.IsContains(useItem)) {
					isUsed = true;
					inventory.TakeItem(useItem);

					speech.ShowMessage(useItem.GetName() + "(을)를 특이하게 생긴 벽에 문질렀더니 문이 생겼습니다!");
					gateClosed.SetActive(true);
				}
				else {
					speech.ShowMessage("벽이 특이하게 생겼습니다. 자세히보니 " + useItem.GetName() + "(와)과 비슷한 그림이 그려져있습니다...");
				}
			}
			else {
				speech.ShowMessage("원래 없던 문이 갑자기 생겼습니다. 힘을 주어 밀었더니 문이 열렸습니다!");

				gateOpened.SetActive(true);
				gateClosed.SetActive(false);
				tileMap.SetActive(false);
			}
		}
	}
}