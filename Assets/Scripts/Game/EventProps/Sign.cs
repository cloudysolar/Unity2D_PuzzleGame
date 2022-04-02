using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Player;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
	public class Sign : EventProp {
		public override void OnInteract(PlayerInventory inventory) {
			speech.ShowMessage("옆에 있는 제단에 무거운 물건을 올리면...\n(글자가 지워져있어 잘 보이지 않는다)");
		}
	}
}