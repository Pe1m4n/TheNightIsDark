using UnityEngine;

namespace Common.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour
    {
        private AudioSource _source;
        public AudioTrack track;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }
        public void Play()
        {
            track.Play(_source);            
        }
    }
}