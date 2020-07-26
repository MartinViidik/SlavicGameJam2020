using System.Collections.Generic;
using UnityEngine;

namespace Utility {

    public static class SoundManager {

        public static void PlaySound(AudioClip clip) {
            var soundGameObject = new GameObject("Sound");
            var audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip);
        }
        
        public static void PlaySoundFromList(List<AudioClip> audioClips) {
            PlaySound(audioClips[Random.Range(0, audioClips.Count)]);
        }

    }

}