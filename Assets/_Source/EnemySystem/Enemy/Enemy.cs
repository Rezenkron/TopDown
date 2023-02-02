using System;
using EnemySystem.Enemy.Data;
using UnityEngine;
using UnityEngine.AI;

namespace EnemySystem.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemySettings enemySettings;
        [field:SerializeField] public float TriggerRadius { get; private set; }
        private GameObject _target;
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = enemySettings.Speed;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        public virtual void Update()
        {
            if (_target)
            {
                Follow();
            }
            else
            {
                GetTarget();
            }
        }

        private void GetTarget()
        {
            if (Physics2D.OverlapCircle(transform.position, TriggerRadius, layerMask: LayerMask.GetMask("Player")))
            {
                _target = Physics2D.OverlapCircle(transform.position, TriggerRadius, layerMask: LayerMask.GetMask("Player"))
                    .gameObject;
            }
        }
        private void Follow()
        {
            _agent.SetDestination(_target.transform.position);
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,TriggerRadius);
        }
    }
}
