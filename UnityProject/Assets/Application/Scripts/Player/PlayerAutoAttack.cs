using System.Collections.Generic;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Player
{
    public class PlayerAutoAttack : MonoBehaviour
    {
        [SerializeField]
        private List<AutoAttackSkillData> _skills = new();
        
        [SerializeField]
        private Transform _muzzle;
        
        private List<float> _timers = new();
        
        private PlayerLevelManager _playerLevelManager;
        
        private void Start()
        {
            _playerLevelManager = PlayerLevelManager.Instance;
            foreach (var _ in _skills)
            {
                _timers.Add(0f);
            }
        }
        
        private void Update()
        {
            int currentLevel = _playerLevelManager?.CurrentLevel ?? 1;
            
            for (int i = 0; i < _skills.Count; i++)
            {
                _timers[i] += Time.deltaTime;
        
                if (_timers[i] >= _skills[i].GetInterval(currentLevel))
                {
                    Shoot(_skills[i], currentLevel);
                    _timers[i] = 0f;
                }
            }
        }
        
        private void Shoot(AutoAttackSkillData skill, int currentLevel)
        {
            GameObject bullet = Instantiate(skill.bulletPrefab, _muzzle.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = skill.direction.normalized * skill.GetSpeed(currentLevel);
        }
    }    
}

