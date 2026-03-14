using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _maxHp = 5;

        [SerializeField]
        private PlayerHealthUI _playerHealthUI;
        
        private int _currentHp;
        private bool _isDead;
        
        void Start()
        {
            _currentHp = _maxHp;
            _playerHealthUI.SetHp(_currentHp, _maxHp);
        }

        public void TakeDamage(int damage)
        {
            if(_isDead) return;
            
            _currentHp -= damage;
            _playerHealthUI.SetHp(_currentHp, _maxHp);

            if (_currentHp <= 0)
            {
                OnDead();
            }
        }

        private void OnDead()
        {
            _isDead = true;
            GameManager.Instance?.EndGame(false);
            Destroy(gameObject);
        }
    }
}