using Unity_Game_Dev_Tutorial.UI;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _maxHp = 100;
        
        private int _currentHp;
        private bool _isDead = false;

        private void Start()
        {
            _currentHp = _maxHp;
        }
        
        public void OnDamaged(int damageAmount)
        {
            if(_isDead) return;
            
            DamagePopup.Create(transform.position, damageAmount);   
            _currentHp -= damageAmount;
            

            if (_currentHp <= 0)
            {
                _isDead = true;
                EnemyKillCounter.Instance.AddKillCount();
                Destroy(gameObject);
            }
        }
    }
}