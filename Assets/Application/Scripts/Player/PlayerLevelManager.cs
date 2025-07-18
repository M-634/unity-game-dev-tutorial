using TMPro;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerLevelManager : MonoBehaviour
    {
        public static PlayerLevelManager Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Animator _anim;
        
        private static readonly int Play = Animator.StringToHash("Play");

        private int _level = 1;
        private int _exp = 0;
        private int _expToNext = 10;

        public int CurrentLevel => _level;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // すでに存在している場合は削除
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンを跨いでも消えないようにする（必要に応じて）
        }

        public void AddExp(int amount)
        {
            _exp += amount;
            if (_exp >= _expToNext)
            {
                LevelUp();
            }
            UpdateUI();
        }

        private void LevelUp()
        {
            _level++;
            _exp = 0;
            _expToNext += 10;
            Debug.Log("Level Up! 現在のレベル: " + _level);
            
            _anim.SetTrigger(Play);
        }

        private void UpdateUI()
        {
            if (_levelText != null)
            {
                _levelText.text = $"Lv. {_level}";
            }
        }
    }
}