using UnityEngine;

namespace Unity_Game_Dev_Tutorial
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall"))
            {
                 Destroy(gameObject);     
            }
        }
    }
}