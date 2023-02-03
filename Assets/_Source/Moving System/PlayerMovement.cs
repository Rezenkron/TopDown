using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingSystem
{
    public sealed class PlayerMovement
    {
        private Rigidbody2D _rb;
        private Player _player;

        private Vector2 direction;

        internal PlayerMovement(Rigidbody2D rb, Player player)
        {
            _rb = rb;
            _player = player;
        }
        internal void Update()
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");

        }

        internal void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + direction * _player._speed * Time.fixedDeltaTime);

        }
    }

}
