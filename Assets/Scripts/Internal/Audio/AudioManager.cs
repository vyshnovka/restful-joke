using System;
using UnityEngine;

namespace Internal.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static Action<string, string> OnPlaySound;
        public static Action<string, string, bool, float> OnPlayBackgroundSound;

        [Header("Sound Sources")]
        [SerializeField]
        private AudioSource sourceMain;
        [SerializeField]
        private AudioSource sourceSFX;

        [Header("Sound Library")]
        [SerializeField]
        private SoundLibrary soundLibrary;

        void OnEnable()
        {
            OnPlaySound += PlaySoundFromCategory;
            OnPlayBackgroundSound += PlayBackgroundSoundFromCategory;
        }

        void OnDisable()
        {
            OnPlaySound -= PlaySoundFromCategory;
            OnPlayBackgroundSound -= PlayBackgroundSoundFromCategory;
        }

        /// <summary>Play sound once with no loop from a separate source. Used for SFX sounds.</summary>
        /// <param name="categoryName">Category name.</param>
        /// <param name="soundName">>Sound to play. If not specified, random sound is playes.</param>
        private void PlaySoundFromCategory(string categoryName, string soundName = null)
        {
            Sound sound;

            if (soundName != null)
            {
                sound = soundLibrary.GetSound(categoryName, soundName);
            }
            else
            {
                var category = soundLibrary.GetSoundCategory(categoryName);
                sound = category[UnityEngine.Random.Range(0, category.Count)];
            }

            PlaySound(sound);
        }

        /// <summary></summary>
        /// <param name="categoryName">Category name.</param>
        /// <param name="soundName">>Sound to play.</param>
        /// <param name="loop">Loop by default.</param>
        /// <param name="delay">No delay by default.</param>
        private void PlayBackgroundSoundFromCategory(string categoryName, string soundName, bool loop = true, float delay = 0f)
        {
            var sound = soundLibrary.GetSound(categoryName, soundName);
            PlayBackgroundSound(sound, loop, delay);
        }

        private void PlaySound(Sound sound)
        {
            Debug.Assert(sound != null && sound.Clip != null, "Invalid SFX sound passed.");

            sourceSFX.PlayOneShot(sound.Clip);
        }

        private void PlayBackgroundSound(Sound sound, bool loop, float delay)
        {
            Debug.Assert(sound != null && sound.Clip != null, $"Invalid theme sound passed.");

            sourceMain.clip = sound.Clip;
            sourceMain.loop = loop;
            sourceMain.PlayDelayed(delay);
        }
    }
}
