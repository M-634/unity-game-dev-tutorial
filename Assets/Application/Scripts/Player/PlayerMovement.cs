using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private enum MoveType
        {
            RigidbodyVelocity = 0,
            Translate = 1
        }
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private MoveType _moveType;
        
        [SerializeField]
        private float _moveSpeed;
        
        private void Start()
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            if(_moveType != MoveType.Translate) return;
            
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            Vector2 velocity = new Vector2(h, v).normalized;
            
            transform.Translate(velocity * (_moveSpeed * Time.deltaTime));
        }

        private void FixedUpdate()
        {
            if(_moveType != MoveType.RigidbodyVelocity) return;
            
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            Vector2 velocity = new Vector2(h, v).normalized;
         
            _rigidbody2D.velocity = velocity * _moveSpeed;
        }
    }
}

