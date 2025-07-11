using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity_Game_Dev_Tutorial
{
    public static class SceneLoader 
    {
        public static void LoadGame()
        {
            SceneManager.LoadScene("GameScene");
        }

        public static void LoadTitle()
        {
            SceneManager.LoadScene("TitleScene");
        }

        public static void LoadResult()
        {
            SceneManager.LoadScene("ResultScene");
        }

        public static void QuitGame()
        {
            Application.Quit();
        }
    }
}