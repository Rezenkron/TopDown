using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class BulletCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
