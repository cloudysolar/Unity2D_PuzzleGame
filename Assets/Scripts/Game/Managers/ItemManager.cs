using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using UnityEngine;

namespace Game_2DPuzzle.Game.Managers {
    // 확장 메소드 : 소스코드를 추가하거나 변경할 수 없는 상태의 어떠한 객체에
    // 내용을 "확장"해서 추가하는 기능 (.NET 전용 기능)

    // 확장 메소드 만들기 1 : 정적 클래스
    public static class ItemCodeMethod {
        private static readonly string[] itemNames = {
            "없음", "곡괭이", "지팡이", "열쇠", "크리스탈"
        };

        // 확장 메소드 만들기 2 : 정적 메소드, 매개변수로 어떠한 객체에서 확장된 것인지 입력
        /*public static string GetName(this ItemCode code) {
            switch (code) {
                case ItemCode.Pickaxe:
                    return "곡괭이";
                case ItemCode.Staff:
                    return "지팡이";
                case ItemCode.Key:
                    return "열쇠";
                case ItemCode.Crystal:
                    return "크리스탈";
                default:
                    return "알 수 없는 아이템";
            }
        }*/

        public static string GetName(this ItemCode code) {
            for (int i = 0; i < itemNames.Length; i++) {
                if (i == (int)code) {
                    return itemNames[i];
                }
            }

            return "알 수 없는 아이템";
        }
    }

    public enum ItemCode {
        None, Pickaxe, Staff, Key, Crystal
    }

    public class ItemManager : MonoBehaviour {
        [Tooltip("ItemCode에 등록된 순서대로 Sprite를 등록할 것!")]
        public List<Sprite> itemImages = new List<Sprite>();

        private static ItemManager _instance = null;

        public static ItemManager Instance {
            private set {
                _instance = value;
            }

            get {
                if (_instance == null) { // 널체킹 (Null Checking)
                    var obj = FindObjectOfType<ItemManager>();

                    if (obj != null) {
                        _instance = obj;
                    }
                    else {
                        _instance = new GameObject("ItemManager").AddComponent<ItemManager>();
                    }
                }

                return _instance;
            }
        }

		private void Awake() {
            var objs = FindObjectsOfType<ItemManager>();

            if (objs.Length != 1) {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
		}

        public Sprite GetItemImage(ItemCode code) {
            return itemImages[(int)code];
        }

        public ItemCode GetItemCodeByName(string name) {
            int enumCount = System.Enum.GetValues(typeof(ItemCode)).Length;

            for (int i = 0; i < enumCount; i++) {
                ItemCode temp = (ItemCode) i;

                if (temp.GetName().Equals(name)) {
                    return temp;
                }
            }

            return ItemCode.None;
        }
	}
}