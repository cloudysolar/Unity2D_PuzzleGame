using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game_2DPuzzle.Game.Player {
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSoundManager : MonoBehaviour {
        [SerializeField]
        private List<AudioClip> footsteps = new List<AudioClip>();

        [SerializeField]
        private AudioClip footstep;

        [SerializeField]
        [Range(0f, 1f)]
        private float volume = 1f;

        private AudioSource aud;

		private void Start() {
			aud = GetComponent<AudioSource>();
		}

		public void PlayFootsteps() {
            int random = UnityEngine.Random.Range(0, footsteps.Count);

            // 재생 중인 오디오가 있더라도 상관없이 오디오를 쌓아가며 재생함 (즉, 중복 재생이 됨)
            aud.PlayOneShot(footsteps[random], volume);

            // 재생 중인 오디오가 있다면 "중지 시킨 뒤" 본인의 오디오를 재생
         // aud.Play();
        }

        public void PlayFootstep() {
            aud.PlayOneShot(footstep, volume);
        }
    }
}