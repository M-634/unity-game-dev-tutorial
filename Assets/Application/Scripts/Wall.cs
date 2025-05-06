using UnityEngine;

namespace Unity_Game_Dev_Tutorial
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "Bullet")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
