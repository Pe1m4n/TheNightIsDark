using UnityEngine;

namespace Fight.Shooting
{
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _reloadTime;
        [SerializeField] private BulletData _bulletData;

        public string Name => _name;
        public float ReloadTime => _reloadTime;
        public BulletData BulletData => _bulletData;
    }
}