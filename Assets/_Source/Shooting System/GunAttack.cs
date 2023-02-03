using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class GunAttack
    {
        private GunSettingsSO _gunSettings;
        private IWeapon _currentWeapon;
        public GunAttack(GunSettingsSO gunSettings)
        {
            _gunSettings = gunSettings;
        }
        public void SetWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }
        public void PerformAttack()
        {
            _currentWeapon.Attack(_gunSettings.BulletPrefab);
        }
    }
}
