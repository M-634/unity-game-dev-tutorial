using System.Collections.Generic;
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
        
        public List<float> intervalPerLevels;
        public List<float> speedPerLevels;
        
        public float GetInterval(int level)
        {
            return intervalPerLevels[Mathf.Clamp(level - 1, 0, intervalPerLevels.Count - 1)];
        }

        public float GetSpeed(int level)
        {
            return speedPerLevels[Mathf.Clamp(level - 1, 0, speedPerLevels.Count - 1)];
        }
    }
}