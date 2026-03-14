using UnityEngine;
using TMPro;

namespace Unity_Game_Dev_Tutorial
{
    public class GameTimerUI : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _timerText;
        
        private void Start()
        {
            //GameSceneがロードされた瞬間にゲームスタート
            if (GameManager.Instance != null)
            {
                GameManager.Instance.StartGame();
            }
        }

        private void Update()
        {
            if (GameManager.Instance == null) return;
            
            float remain = Mathf.Max(0f, GameManager.Instance.MaxTime - GameManager.Instance.ElapsedTime);
            int minutes = Mathf.FloorToInt(remain / 60);
            int seconds = Mathf.FloorToInt(remain % 60);
            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}