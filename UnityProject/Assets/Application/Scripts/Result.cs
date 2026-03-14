using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unity_Game_Dev_Tutorial
{
    public class Result : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _killText;

        [SerializeField]
        private TextMeshProUGUI _timeText;
        
        [SerializeField]
        private Button _loadGameButton;
        
        [SerializeField]
        private Button _loadTitleButton;

        private void Start()
        {
            int kills = 0;
            float time = 0f;
            
            if (GameManager.Instance != null)
            { 
                kills = GameManager.Instance.KillCount;
                time = GameManager.Instance.ElapsedTime;
            }

            _killText.text = $"Defeat Enemy Count: {kills}";
            _timeText.text = $"Survival Time Count : {Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
            
            _loadGameButton.onClick.AddListener(OnRetryButton);
            _loadTitleButton.onClick.AddListener(OnTitleButton);
        }
        
        private void OnDestroy()
        {
            _loadGameButton.onClick.RemoveListener(OnRetryButton);
            _loadTitleButton.onClick.RemoveListener(OnTitleButton);
        }

        private void OnRetryButton()
        {
            SceneLoader.LoadGame();
        }

        private void OnTitleButton()
        {
            SceneLoader.LoadTitle();
        }
    }
}