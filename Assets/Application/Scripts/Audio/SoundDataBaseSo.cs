using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Sound
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Audio/SoundData", order = 1)]
    public class SoundDataBaseSo : ScriptableObject
    {
        [SerializeField] 
        private List<SoundData> _soundMap = new List<SoundData>();

        [CanBeNull]
        public SoundData GetSoundData(string key)
        {
            return _soundMap.FirstOrDefault(x => x.Key == key);
        }
    }

    [Serializable]
    public class SoundData
    {
        [SerializeField, Header("keyを指定する")]
        private string _key; 
        
        [SerializeField, Header("サウンドの種類を設定する")] 
        private SoundDataUtility.SoundType _type;
        
        [SerializeField, Header("ループ再生させるか")]
        private bool _isLoop;

        [SerializeField, Header("即再生させるか")]
        private bool _playOnAwake;
        
        [SerializeField, Header("Volume設定"), Range(0f, 1f)]
        private float _volume = 0.5f;
            
        [SerializeField, Header("AudioClipをアサインする")]
        private AudioClip _clip;
        
        public string Key => _key;
        public SoundDataUtility.SoundType Type => _type;
        public bool IsLoop => _isLoop;
        public bool PlayOnAwake => _playOnAwake;
        public float Volume => _volume;
        public AudioClip Clip => _clip;
    }
}
