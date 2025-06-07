using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] 
        private RectTransform canvas;
        
        [SerializeField]
        private RectTransform healthBar;

        private float width;

        private void Start()
        {
            width = canvas.sizeDelta.x;
        }
        
        public void SetHp(int current, int max)
        {
            float value = Mathf.Max(1f - (float)current / max, 0f) * width;
            healthBar.sizeDelta = new Vector2(Mathf.Min(value, width) * -1f, 0f);
        }
    }
}