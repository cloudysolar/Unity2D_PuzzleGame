using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Managers;
using Game_2DPuzzle.Game.Player;
using Game_2DPuzzle.Game.UI;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
    public abstract class EventProp : MonoBehaviour {
        [SerializeField]
        protected Speech speech;

        [SerializeField]
        protected ItemCode giveItem;

        [SerializeField]
        protected ItemCode useItem;

        [SerializeField]
        protected bool isUsed = false;

		public abstract void OnInteract(PlayerInventory inventory);
    }
}