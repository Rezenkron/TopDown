using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemy
{
    public class MeleeEnemy : Enemy
    {
        protected override void Attack()
        {
            base.Attack();
            Hit();
        }

        private void Hit()
        {
            
        }
    }
}
