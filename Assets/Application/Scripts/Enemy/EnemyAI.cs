using System;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;

        private Transform _player;

        private void Start()
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj == null)
            {
                return;
                throw new NullReferenceException("playerObj is null");
            }
            
            _player = playerObj.transform;
        }

        private void Update()
        {
            if (_player == null) return;

            Vector2 direction = (_player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * _moveSpeed * Time.deltaTime);
        }
    }
}