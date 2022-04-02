using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_2DPuzzle.Intro {
    public class MenuManager : MonoBehaviour {
        public void OnGameStartButtonClicked() {
            SceneManager.LoadScene(1);
        }

        public void OnGameExitButtonClicked() {
            Application.Quit();
        }
    }
}
