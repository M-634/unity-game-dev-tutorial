using Unity_Game_Dev_Tutorial.Player;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Enemy
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] 
        private int _damageAmount = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
            {
                playerHealth.TakeDamage(_damageAmount);
            }
        }
    }
}