using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class Pistol : IWeapon
    {
        public GunSettingsSO GunSettings { get; set; }
        public Transform ShotPoint { get; set; }

        public Pistol(GunSettingsSO gunSettings,Transform shotPoint)
        {
            GunSettings = gunSettings;
            ShotPoint = shotPoint;
        }
        public void Attack(Rigidbody2D bulletPrefab)
        {
            bulletPrefab = GunSettings.BulletPrefab;
            Rigidbody2D currentBullet;
            currentBullet = GameObject.Instantiate(bulletPrefab,ShotPoint);
            currentBullet.AddRelativeForce(Vector2.right * GunSettings.BulletSpeed, ForceMode2D.Impulse);
            currentBullet.gameObject.transform.parent = null;
        }
        
    }
}
