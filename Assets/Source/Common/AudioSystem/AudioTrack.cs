using UnityEngine;

namespace Common.AudioSystem
{
    public class AudioTrack : ScriptableObject
    {
        [SerializeField] private AudioClip _clip;

        public void Play(AudioSource source)
        {
            source.clip = _clip;
            source.Play();
        }
    }
}