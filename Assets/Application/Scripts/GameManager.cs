using Unity_Game_Dev_Tutorial.Player;

namespace Unity_Game_Dev_Tutorial
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public GameState CurrentState { get; private set; }
        public float ElapsedTime { get; private set; }
        public int KillCount { get; private set; }

        [SerializeField]
        private float _maxTime = 600f; // 10分
        public float MaxTime => _maxTime;

        private void Awake()
        {
            if (Instance != null) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (CurrentState != GameState.Playing) return;

            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= _maxTime)
            {
                EndGame(true); // タイムアップ勝利
            }
        }

        public void StartGame()
        {
            ElapsedTime = 0f;
            KillCount = 0;

            if (PlayerLevelManager.Instance != null)
            {
                PlayerLevelManager.Instance.UpdateUI();
            }
            
            CurrentState = GameState.Playing;
        }

        public void AddKill()
        {
            KillCount++;
        }

        public void EndGame(bool isTimeUp)
        {
            CurrentState = isTimeUp ? GameState.TimeUp : GameState.GameOver;
            
            if (PlayerLevelManager.Instance != null)
            {
                PlayerLevelManager.Instance.ResetLevel();
            }
            
            SceneManager.LoadScene("ResultScene");
        }
    }

    public enum GameState
    {
        Title = 0,
        Playing = 1,
        GameOver = 2,
        TimeUp = 3
    }
}