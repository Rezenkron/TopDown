using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingSystem
{
    public sealed class CrosshairRotation
    {
        private Rigidbody2D _rb;
        private Transform _playerRotation;
        private Camera _camera;

        private Vector2 mousePos;
        internal CrosshairRotation(Camera camera, Rigidbody2D rb)
        {
            _rb = rb;
            _camera = camera;
        }

        internal void Start()
        {
            _playerRotation = _rb.gameObject.GetComponent<Transform>();
        }

        internal void Update()
        {
            mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        internal void FixedUpdate()
        {
            Vector2 lookDir = mousePos - _rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;

        }
    }
}
