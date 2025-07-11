namespace Unity_Game_Dev_Tutorial
{
    using UnityEngine;
    using TMPro;

    public class GameTimerUI : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _timerText;

        private void Update()
        {
            float remain = Mathf.Max(0f, GameManager.Instance.MaxTime - GameManager.Instance.ElapsedTime);
            int minutes = Mathf.FloorToInt(remain / 60);
            int seconds = Mathf.FloorToInt(remain % 60);
            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}