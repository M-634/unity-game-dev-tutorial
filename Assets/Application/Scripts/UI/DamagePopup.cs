using TMPro;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.UI
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _popupText;
        
        [SerializeField] 
        private float _floatSpeed = 1f;
        
        [SerializeField]
        private float _duration = 0.5f;
        
        public static void Create(Vector3 position, int damage)
        {
            var resourcePrefab = Resources.Load<GameObject>("DamagePopup"); 
            GameObject popup = Instantiate(resourcePrefab, position, Quaternion.identity);
            popup.GetComponent<DamagePopup>().SetDamage(damage);
        }
        
        private void SetDamage(int damage)
        {
            _popupText.text = damage.ToString();
            Destroy(gameObject, _duration);
        }

        private void Update()
        {
            transform.position += Vector3.up * _floatSpeed * Time.deltaTime;
        }
    }
}