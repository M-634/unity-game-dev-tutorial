using UnityEngine;
using UnityEngine.UI;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField]
        private Slider _hpSlider;
      
        public void SetHp(int current, int max)
        {
            _hpSlider.value = (float)current / max;
        }
    }
}