using System.Collections.Generic;
using UnityEngine;

namespace Internal.Audio
{
    [CreateAssetMenu(fileName = "Sound Library", menuName = "Scriptable Objects/Sound Library")]
    public class SoundLibrary : ScriptableObject
    {
        public List<DynamicSoundCategory> soundCategories = new();

        /// <summary>Get sounds category by name.</summary>
        /// <param name="categoryName">Category name.</param>
        /// <returns>A list of sounds.</returns>
        public List<Sound> GetSoundCategory(string categoryName)
        {
            var category = soundCategories.Find(c => c.categoryName == categoryName);

            Debug.Assert(category != null, $"Missing sound category {categoryName}!");

            return category.sounds;
        }

        /// <summary>Get a sound directly by category name and sound name.</summary>
        /// <param name="categoryName">Category name.</param>
        /// <param name="soundName">Sound name.</param>
        /// <returns>A sound.</returns>
        public Sound GetSound(string categoryName, string soundName)
        {
            var sounds = GetSoundCategory(categoryName);

            var sound = sounds.Find(x => x.Name == soundName);

            Debug.Assert(sound == null, $"Missing sound {soundName} from {categoryName}!");

            return sound;
        }
    }
}
