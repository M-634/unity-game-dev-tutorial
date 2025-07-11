using UnityEngine;
using UnityEngine.UI;

namespace Unity_Game_Dev_Tutorial
{
    public class Title : MonoBehaviour
    {
        [SerializeField]
        private Button _loadGameButton;
        
        [SerializeField]
        private Button _quitGameButton;

        private void Start()
        {
            _loadGameButton.onClick.AddListener(OnStartButton);
            _quitGameButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDestroy()
        {
            _loadGameButton.onClick.RemoveListener(OnStartButton);
            _quitGameButton.onClick.RemoveListener(OnQuitButton);
        }

        private void OnStartButton()
        {
            SceneLoader.LoadGame();
        }

        private void OnQuitButton()
        {
            SceneLoader.QuitGame();
        }
    }
}