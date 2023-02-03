using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class GunBehaviour : MonoBehaviour
    {
        [SerializeField] private GunSettingsSO _gunSettings;
        [SerializeField] private KeyCode _attackKey;
        [SerializeField] private Transform _shotPoint;

        private AttackPerformer attackPerformer;

        private void Awake()
        {
            attackPerformer = new AttackPerformer(_attackKey, _gunSettings, _shotPoint);
            
        }
        private void Start()
        {
            attackPerformer.Start();
        }

        private void Update()
        {
            attackPerformer.Update();
        }
    }
}
