using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingSystem
{
    public class AttackPerformer
    {
        private KeyCode _keyCode;
        private GunSettingsSO _gunSettings;
        private GunAttack _gunAttack;
        private float _startFrequency;
        private float _Frequency;
        private Transform _shotPoint;
        bool startTimer = false;

        private Pistol pistol;
        public AttackPerformer(KeyCode keyCode, GunSettingsSO gunSettings, Transform shotPoint)
        {
            _keyCode = keyCode;
            _gunSettings = gunSettings;
            _shotPoint = shotPoint;
        }
        public void Start()
        {
            _startFrequency = _gunSettings.Frequency;
            _Frequency = _startFrequency;
            _gunAttack = new GunAttack(_gunSettings);
            pistol = new Pistol(_gunSettings,_shotPoint);
            _gunAttack.SetWeapon(pistol);
        }

        public void Update()
        {
            Timer();
            if (Input.GetKey(_keyCode))
            {
                if (Timer() == _startFrequency)
                {
                    _gunAttack.PerformAttack();
                    startTimer = true;
                }
            }
        }

        public float Timer()
        {
            if (startTimer)
            {
                _Frequency -= Time.deltaTime;
                if(_Frequency <= 0)
                {
                    startTimer = false;
                    _Frequency = _startFrequency;
                }
            }
            return _Frequency;
        }
    }
}
