using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemy
{
    public class RangeEnemy : Enemy
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;

        protected override void Attack()
        {
            base.Attack();
            Shoot(bullet);
        }

        private void Shoot(GameObject projectile)
        {
            Instantiate(projectile, firePoint.position, transform.rotation);
        }
    }
}
