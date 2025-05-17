using System;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]
        private Transform _muzzle;
        
        [SerializeField]
        private GameObject _bulletPrefab;
        
        [SerializeField]
        private float _bulletSpeed = 10f;
        
        private void Start()
        {
            if (_muzzle == null)
            {
                throw new NullReferenceException("_muzzle is null");
            }

            if (_bulletPrefab == null)
            {
                throw new NullReferenceException("_bulletPrefab is null");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, Quaternion.identity);
            
            if(bullet.TryGetComponent(out Rigidbody2D rigidBody2D))
            {
                Vector2 velocity = _muzzle.up * _bulletSpeed;
                rigidBody2D.velocity = velocity;
            }
            else
            {
                Debug.LogWarning($"{bullet.name} has no Rigidbody2D component");
            }
        }
    }
}
