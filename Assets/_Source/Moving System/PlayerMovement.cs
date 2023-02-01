using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingSystem
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] internal float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;


        private Mover mover;

        private void Awake()
        {
            mover = new Mover(_rigidbody, this);
        }
        void Update()
        {
            mover.Update();
        }

        private void FixedUpdate()
        {
            mover.FixedUpdate();
        }
    }
}
