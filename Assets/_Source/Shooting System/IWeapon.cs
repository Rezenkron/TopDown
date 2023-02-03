using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public interface IWeapon
    {
        public GunSettingsSO GunSettings { get; set; }
        public Transform ShotPoint { get; set; }
        public void Attack(Rigidbody2D bulletPrefab);
    }
}
