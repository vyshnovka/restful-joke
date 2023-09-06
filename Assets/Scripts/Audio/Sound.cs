using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Scriptable Objects/Sound")]
public class Sound : ScriptableObject
{
    public string Name;
    public AudioClip Clip;
}
