using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    [CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/AutoAttackSkill", order = 0)]
    public class AutoAttackSkillData : ScriptableObject
    {
        public string skillName;
        public GameObject bulletPrefab;
        public float interval;
        public float speed;
        public Vector2 direction;
    }
}