using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    [CreateAssetMenu(fileName = "GunSettings", menuName = "SO/GunSettings")]
    public class GunSettingsSO : ScriptableObject
    {
        public int Damage;
        public float Frequency;
        public float BulletSpeed;
        public Rigidbody2D BulletPrefab;
        //public float ReloadTime;
    }
}
