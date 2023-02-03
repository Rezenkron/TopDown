using System;
using EnemySystem.Enemy.Data;
using UnityEngine;
using UnityEngine.AI;

namespace EnemySystem.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemySettings enemySettings;
        [field: SerializeField] public float TriggerRadius { get; private set; }

        public event Action OnEnemyDamageTaken;

        private GameObject _target;
        private NavMeshAgent _agent;
        private float _health, _attackDelay;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;

            _agent.speed = enemySettings.Speed;
            _agent.stoppingDistance = enemySettings.AttackRange;
            _health = enemySettings.Health;
        }

        private void Update()
        {
            if (_target)
            {
                Follow();
                TryAttack();
            }
            else
            {
                GetTarget();
            }

            _attackDelay += Time.deltaTime;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            var position = transform.position;
            Gizmos.DrawWireSphere(position, TriggerRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position, enemySettings.AttackRange);
        }

        private void GetTarget()
        {
            if (Physics2D.OverlapCircle(transform.position, TriggerRadius, layerMask: LayerMask.GetMask("Player")))
            {
                _target = Physics2D.OverlapCircle(transform.position, TriggerRadius,
                        layerMask: LayerMask.GetMask("Player"))
                    .gameObject;
            }
        }

        private void Follow()
        {
            var targetPosition = _target.transform.position;
            _agent.SetDestination(targetPosition);

            var relative = transform.InverseTransformPoint(targetPosition);
            var angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
        }

        private void TryAttack()
        {
            if (Vector2.Distance(_target.transform.position, transform.position) <= _agent.stoppingDistance &&
                _attackDelay >= enemySettings.AttackSpeed)
            {
                var raycastHit2D = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity,
                    layerMask: LayerMask.GetMask("Player", "Obstacle"));
                if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Attack();
                }
            }
        }

        private void TakeDamage(float value)
        {
            OnEnemyDamageTaken?.Invoke();

            _health -= value;
            if (_health <= 0)
            {
                Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }

        protected virtual void Attack()
        {
            _attackDelay = 0;
        }
    }
}