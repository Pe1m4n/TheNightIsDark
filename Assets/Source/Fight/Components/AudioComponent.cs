using Common.AudioSystem;
using UnityEngine;

namespace Fight
{
    public class AudioComponent
    {
        private readonly AudioSource _source;

        public AudioComponent(AudioSource source)
        {
            _source = source;
        }

        public void Play(AudioTrack track)
        {
            track.Play(_source);
        }
    }
}