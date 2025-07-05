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
        private float _distanceToMove = 3f;

        [SerializeField, Range(0f, 5f)]
        private float _moveDuration = 0.5f;

        private Transform _player;
        private bool _isMoving = false;

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
                transform.DOMove(_player.position, _moveDuration).SetEase(Ease.InOutSine);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (PlayerLevelManager.Instance != null)
                {
                    PlayerLevelManager.Instance.AddExp(_expValue);
                }
                Destroy(gameObject);
            }
        }
    }
}