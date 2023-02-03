using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingSystem
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] internal float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Camera _camera;


        private PlayerMovement playerMovement;
        private CrosshairRotation crosshairRotation;

        private void Awake()
        {
            playerMovement = new PlayerMovement(_rigidbody, this);
            crosshairRotation = new CrosshairRotation(_camera, _rigidbody);
        }
        private void Start()
        {
            crosshairRotation.Start();
        }
        void Update()
        {
            playerMovement.Update();
            crosshairRotation.Update();
        }

        private void FixedUpdate()
        {
            playerMovement.FixedUpdate();
            crosshairRotation.FixedUpdate();
        }
    }
}
