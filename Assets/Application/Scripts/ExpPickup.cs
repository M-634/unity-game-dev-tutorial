using UnityEngine;
using DG.Tweening;
using Unity_Game_Dev_Tutorial.Player;

namespace Unity_Game_Dev_Tutorial
{
    public class ExpPickup : MonoBehaviour
    {
        [SerializeField]
        private int _expValue = 5;

        [SerializeField, Range(0f, 50f)]
        private float _distanceToMove = 10f;
        
        [SerializeField, Range(0f, 5f)]
        private float _moveTime = 0.3f;

        private Transform _player;
        private bool _isMoving;
        private Tweener _moveTween;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (_isMoving || _player == null) return;
            
            float distance = Vector2.Distance(transform.position, _player.position);
            if (distance < _distanceToMove)
            {
                _isMoving = true;
                StartFollowingPlayer();
                Debug.Log($"{gameObject.name} start moving");
            }
        }

        private void StartFollowingPlayer()
        {
            _moveTween = transform
                .DOMove(_player.position, _moveTime)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart)
                .OnUpdate(() =>
                {
                    if (_moveTween.IsActive())
                    {
                        _moveTween.ChangeEndValue(_player.position, true);
                    }
                });
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_moveTween != null && _moveTween.IsActive())
                {
                    _moveTween.Kill(); 
                }
                
                if (PlayerLevelManager.Instance != null)
                {
                    PlayerLevelManager.Instance.AddExp(_expValue);
                }
                Destroy(gameObject);
            }
        }
    }
}