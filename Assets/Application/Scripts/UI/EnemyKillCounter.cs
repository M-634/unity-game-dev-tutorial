using UnityEngine;
using UnityEngine.UI;

namespace Unity_Game_Dev_Tutorial.UI
{
    public class EnemyKillCounter : MonoBehaviour
    {
        [SerializeField] 
        private Text _killCountText;
        
        private int _killCount;
        
        public static EnemyKillCounter Instance { get; private set; }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            Instance = null;
        }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddKillCount()
        {
            _killCount++;
            _killCountText.text = _killCount.ToString();
        }
    }
}