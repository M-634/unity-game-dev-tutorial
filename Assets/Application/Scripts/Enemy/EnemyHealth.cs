using System.Collections;
using Unity_Game_Dev_Tutorial.UI;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _maxHp = 100;
        
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField]
        private ExpPickup _expPickupItemPrefab;
        
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
            StartCoroutine(Flash());
            
            if (_currentHp <= 0)
            {
                OnDead();
            }
        }

        private void OnDead()
        {
            _isDead = true;

            if (EnemyKillCounter.Instance != null)
            {
                EnemyKillCounter.Instance.AddKillCount();
            }

            if (_expPickupItemPrefab != null)
            {
               Instantiate(_expPickupItemPrefab, transform.position, Quaternion.identity);    
            }
            
            Destroy(gameObject);
        }
        

        private IEnumerator Flash()
        {
            var tempColor = _spriteRenderer.color;
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.color = tempColor;
        }
    }
}