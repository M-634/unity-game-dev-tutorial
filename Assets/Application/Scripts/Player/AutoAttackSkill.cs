using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    // Scriptable Objectとの比較説明用
    [System.Serializable]
    public class AutoAttackSkill
    {
        public string name;
        public GameObject bulletPrefab;
        public float interval;
        public float speed;
        public Vector2 direction;
    }
}