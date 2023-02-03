using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rb.velocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                // deal damage to player
            }

            if (col.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
