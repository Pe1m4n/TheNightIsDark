using Common.AudioSystem;
using UnityEngine;

namespace Fight.Shooting
{
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _bulletCapacity;
        [SerializeField] private BulletData _bulletData;
        [SerializeField] private AudioTrack _shootingSound;

        public string Name => _name;
        public float ReloadTime => _reloadTime;
        public int BulletCapacity => _bulletCapacity;
        public BulletData BulletData => _bulletData;
        public AudioTrack ShootingSound => _shootingSound;
    }
}