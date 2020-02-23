using Common.AudioSystem;
using Fight.World;
using UnityEngine;

namespace Fight
{
    public class ChangeMusicSound : MonoBehaviour, IWorldStateListener
    {
        [SerializeField] private AudioTrack _dayStart;
        [SerializeField] private AudioTrack _nightStart;
        [SerializeField] private AudioSource _audioSource;
        public void OnWorldStateChanged(WorldState state)
        {
            if (state == WorldState.Day)
            {
                _dayStart.Play(_audioSource);
                return;
            }

            _nightStart.Play(_audioSource);
        }
    }
}