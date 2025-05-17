using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] 
        private int _health = 100;

        [SerializeField]
        private bool _isDead = false;
        
        public void OnDamaged(int damageAmount)
        {
            if(_isDead) return;
            
            _health -= damageAmount;

            if (_health <= 0)
            {
                _isDead = true;
                Destroy(gameObject);
            }
        }
    }
}