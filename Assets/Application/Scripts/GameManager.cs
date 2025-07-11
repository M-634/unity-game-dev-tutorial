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
            CurrentState = GameState.Playing;
        }

        public void AddKill()
        {
            KillCount++;
        }

        public void EndGame(bool timeUp)
        {
            CurrentState = GameState.GameOver;
            SceneManager.LoadScene("ResultScene");
        }
    }

    public enum GameState
    {
        Title,
        Playing,
        GameOver
    }
}