using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Managers;
using Game_2DPuzzle.Game.Player;

using UnityEngine;

namespace Game_2DPuzzle.Game.EventProps {
    public class Monument : EventProp {
        [SerializeField]
        private GameObject targetObject; // 아이템을 사용했을 때 삭제할 오브젝트

        public override void OnInteract(PlayerInventory inventory) {
            // Debug.Log("Monument 상호작용 실행!");

            if (!isUsed) {
                if (inventory.IsContains(useItem)) {
                    inventory.TakeItem(ItemCode.Staff);
                    speech.ShowMessage("아이템 '" + useItem.GetName() + "'(을)를 사용하였습니다!");

                    StartCoroutine("UsingMonument");
                }
                else {
                    speech.ShowMessage("이 비석을 작동시키려면 특수한 아이템이 필요한 것 같습니다...");
                }
            }
        }

        IEnumerator UsingMonument() {
            GameObject glow = transform.GetChild(0).gameObject;
            glow.SetActive(true);

            yield return new WaitForSeconds(2.5f);
            glow.SetActive(false);

            // Debug.Log("플레이어가 지팡이를 마법이 깃든 비석에 사용해 길을 막고 있던 돌을 파괴하였습니다!");
            speech.ShowMessage("플레이어가 지팡이를 마법이 깃든 비석에 사용해 길을 막고 있던 돌을 파괴하였습니다!");
            Destroy(targetObject);
        }
    }
}