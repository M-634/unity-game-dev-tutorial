using TMPro;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial
{
    public class Result : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _killText;

        [SerializeField]
        private TextMeshProUGUI _timeText;

        private void Start()
        {
            int kills = GameManager.Instance?.KillCount ?? 0;
            float time = GameManager.Instance?.ElapsedTime ?? 0f;

            _killText.text = $"撃破数: {kills}";
            _timeText.text = $"生存時間: {Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
        }

        public void OnRetryButton()
        {
            SceneLoader.LoadGame();
        }

        public void OnTitleButton()
        {
            SceneLoader.LoadTitle();
        }
    }
}