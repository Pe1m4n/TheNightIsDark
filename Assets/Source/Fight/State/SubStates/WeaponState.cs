using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Fight.Shooting
{
    public class WeaponState
    {
        public int AmmoLoaded { get; private set; }
        public int TotalAmmo { get; private set; }
        public bool Reloading { get; private set; }
        public WeaponData WeaponData { get; }
        
        public WeaponState(WeaponData data)
        {
            WeaponData = data;
        }

        public void SetAmmo(int count)
        {
            AmmoLoaded = count;
        }

        private bool CanShoot()
        {
            return AmmoLoaded > 0 && !Reloading;
        }

        public bool Shoot()
        {
            if (!CanShoot())
            {
                return false;
            }
            AmmoLoaded--;
            return true;
        }

        public async void Reload(bool instant = false)
        {
            if (Reloading)
            {
                return;
            }

            if (!instant)
            {
                await Task.Delay(TimeSpan.FromSeconds(WeaponData.ReloadTime));
            }

            //var countToLoad = Mathf.Clamp(TotalAmmo, 0, WeaponData.BulletCapacity);
            var countToLoad = WeaponData.BulletCapacity;
            TotalAmmo -= countToLoad;
            AmmoLoaded = countToLoad;
            
            Reloading = false;
        }
    }
}