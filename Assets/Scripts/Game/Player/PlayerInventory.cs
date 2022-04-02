using System.Collections;
using System.Collections.Generic;

using Game_2DPuzzle.Game.Managers;

using UnityEngine;
using UnityEngine.UI;

namespace Game_2DPuzzle.Game.Player {
    public class PlayerInventory : MonoBehaviour {
        public GameObject invRoot;

        private List<GameObject> inv = new List<GameObject>();
        private List<ItemCode> inv_items = new List<ItemCode>();

		private void Start() {
            // 해당 오브젝트에 속한 자식 오브젝트의 개수를 표시
            int count = invRoot.transform.childCount;

            for (int i = 0; i < count; i++) {
                inv.Add(invRoot.transform.GetChild(i).gameObject);
                inv_items.Add(ItemCode.None);
            }
		}

		private void Update() {
            // 아이템이 인벤토리에 들어왔을 때 해당 위치의 UI에 이미지를 표시
            for (int i = 0; i < inv_items.Count; i++) {
                Image image = inv[i].transform.GetChild(1).GetComponent<Image>();

                if (inv_items[i] != ItemCode.None) {
                    image.sprite = ItemManager.Instance.GetItemImage(inv_items[i]);
                    image.enabled = true;
                }
                else {
                //  image.sprite = ItemManager.Instance.GetItemImage(ItemCode.None);
                    image.sprite = null;
                    image.enabled = false;
                }
            }
        }

        // 플레이어에게 아이템을 지급하는 메소드
        public void GiveItem(ItemCode item) {
            for (int i = 0; i < inv_items.Count; i++) {
                if (inv_items[i] == ItemCode.None) {
                    inv_items[i] = item;
                    Debug.Log("플레이어에게 아이템 '" + item.GetName() + "'(을)를 지급하였습니다.");
                    break;
                }

                // 마지막 인벤토리까지 비교했으나 ItemCode.None인 인벤토리가 없는 경우
                // 즉, 빈 인벤토리 칸이 없는 경우
                if (i == (inv_items.Count - 1)) {
                    Debug.LogWarning("플레이어의 인벤토리에 빈 공간이 없어서 아이템 '" + item.GetName() 
                        + "'(을)를 지급할 수 없습니다!");
                }
            }
        }

        // 플레이어에게서 아이템을 뺏어오는(삭제하는) 메소드
        public void TakeItem(ItemCode item) {
            for (int i = 0; i < inv_items.Count; i++) {
                if (inv_items[i] == item) {
                    inv_items[i] = ItemCode.None;
                    Debug.Log("플레이어에게서 아이템'" + item.GetName() + "'(을)를 인벤토리에서 삭제했습니다.");
                    break;
                }

                // 마지막 인벤토리까지 비교했으나 item이 인벤토리에 저장되지 않은 경우
                // 즉, 해당 아이템을 소지하고 있지 않은 경우
                if (i == (inv_items.Count - 1)) {
                    Debug.LogWarning("플레이어가 아이템 '" + item.GetName() + "'(을)를 가지고 있지 않아 삭제할 수 없습니다!");
                }
            }
        }

        // 플레이어의 인벤토리를 초기화하는 메소드
        public void TakeAllItems() {
            for (int i = 0; i < inv_items.Count; i++) {
                inv_items[i] = ItemCode.None;
            }

            Debug.Log("플레이어의 인벤토리를 초기화하였습니다.");
        }

        // 플레이어의 인벤토리에 해당 아이템이 있는지 확인하는 메소드
        public bool IsContains(ItemCode item) {
            for (int i = 0; i < inv_items.Count; i++) {
                if (inv_items[i] == item) {
                    return true;
                }
            }

            return false;
        }
    }
}