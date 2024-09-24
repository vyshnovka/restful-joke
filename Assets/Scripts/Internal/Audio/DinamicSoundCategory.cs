using System.Collections.Generic;

namespace Internal.Audio
{
    [System.Serializable]
    public class DynamicSoundCategory
    {
        public string categoryName;
        public List<Sound> sounds = new();
    }
}