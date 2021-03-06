﻿using Common.AudioSystem;
using Fight.World;
using UnityEngine;

namespace Fight
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicComponent : MonoBehaviour, IWorldStateListener
    {
        [SerializeField] private AudioTrack _dayMusic;
        [SerializeField] private AudioTrack _nightMusic;
        
        private AudioSource _source;
        private void Start()
        {
            _source = GetComponent<AudioSource>();
            _dayMusic.Play(_source);
        }
        
        public void OnWorldStateChanged(WorldState state)
        {
            _source.Stop();
            if (state == WorldState.Day)
            {
                _dayMusic.Play(_source);
                return;
            }
            
            _nightMusic.Play(_source);
        }
    }
}