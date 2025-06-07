using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _maxHp = 5;

        [SerializeField]
        private PlayerHealthUI _healthUI;

        private int _currentHp;
        private bool _isDead;
        
        void Start()
        {
            _currentHp = _maxHp;
            _healthUI.SetHp(_currentHp, _maxHp);
        }

        public void TakeDamage(int damage)
        {
            if(_isDead) return;
            
            _currentHp -= damage;
            _currentHp = Mathf.Max(_currentHp, 0);

            _healthUI.SetHp(_currentHp, _maxHp);

            if (_currentHp <= 0)
            {
                _isDead = true;
                Debug.Log("Game Over!");
                gameObject.SetActive(false); 
            }
        }
    }
}