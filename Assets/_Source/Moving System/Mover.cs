using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingSystem
{
    public sealed class Mover
    {
        private Rigidbody2D _rb;
        private PlayerMovement _playerMovement;

        private Vector2 direction;

        internal Mover(Rigidbody2D rb, PlayerMovement playerMovement)
        {
            _rb = rb;
            _playerMovement = playerMovement;
        }
        internal void Update()
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");

        }

        internal void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + direction * _playerMovement._speed * Time.fixedDeltaTime);

        }
    }

}
