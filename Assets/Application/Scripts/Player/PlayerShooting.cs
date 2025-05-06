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
        private float _bulletSpeed = 1000f;
        
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
            if (Input.GetKeyDown("space"))
            {
                GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, Quaternion.identity);
                bullet.name = "Bullet";
                
                if(bullet.TryGetComponent(out Rigidbody2D rigidBody2D))
                {
                    Vector2 force = _muzzle.up * _bulletSpeed;
                    rigidBody2D.AddForce(force);
                }
                else
                {
                    Debug.LogWarning($"{bullet.name} has no Rigidbody2D component");
                }
            }
        }
    }
}
