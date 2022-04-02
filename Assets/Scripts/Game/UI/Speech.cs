using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game_2DPuzzle.Game.UI {
    public class Speech : MonoBehaviour {
        [SerializeField]
        private Text message;

        [SerializeField]
        private Image nextScript;

        [SerializeField]
        [Range(0f, 1f)]
        private float textSpeed = 0.1f;

        private bool isShowMessage = false; // 현재 메시지를 출력하고 있는지 확인
        private bool isEnd = false; // 깜빡임을 끝내는 변수

        [HideInInspector]
        public bool isShowWindow = false; // 현재 메시지 창이 표시되고 있는지 확인

        private void Start() {
            nextScript.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

		private void Update() {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
                if (isShowMessage) {
                    isShowMessage = false;
                }

                if (nextScript.gameObject.activeInHierarchy) {
                    isEnd = true;
                }
            }
		}

        // 기본 메소드
        public void ShowMessage(string message) {
            if (!gameObject.activeInHierarchy) {
                gameObject.SetActive(true);
            }

            if (!isShowWindow) {
                StartCoroutine("ShowText", message);
            }
        }

        IEnumerator ShowText(string text) {
            isShowWindow = true;
            isShowMessage = true;
            isEnd = false;

            message.text = "";

            for (int i = 0; i < text.Length; i++) {
                yield return new WaitForSeconds(textSpeed);
                message.text += text[i];

                if (!isShowMessage) {
                    message.text = text;
                    break;
                }
            }

            isShowWindow = false;
            StartCoroutine("ShowBlinkDownArrow");
        }

        IEnumerator ShowBlinkDownArrow() {
            float cooltime = 0.25f;

            nextScript.gameObject.SetActive(true);

            while (true) {
                nextScript.enabled = true;
                yield return new WaitForSeconds(cooltime);

                nextScript.enabled = false;
                yield return new WaitForSeconds(cooltime);

                if (isEnd) {
                    break;
                }
            }

            nextScript.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}