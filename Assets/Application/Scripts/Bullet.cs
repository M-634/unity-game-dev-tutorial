using UnityEngine;

namespace Unity_Game_Dev_Tutorial
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] 
        private int _damageAmount = 10;
        
        [SerializeField] 
        private bool _isDestroyedOnCollisionEnemy = false;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall"))
            {
                 Destroy(gameObject);  
                 return;
            }

            if (collision.TryGetComponent<Enemy.EnemyHealth>(out var enemy))
            {
                 enemy.OnDamaged(_damageAmount);

                 if (_isDestroyedOnCollisionEnemy)
                 {
                     Destroy(gameObject);
                 }
            }
        }
    }
}