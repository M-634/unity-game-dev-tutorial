﻿using UnityEngine;

namespace Unity_Game_Dev_Tutorial.Sound
{
    public static class SoundDataUtility
    {
        public static class KeyConfig
        {
            public static class Se
            {
                public static readonly string Shoot = "Shoot";
            }
        
            public static class Bgm
            {
                public  static readonly string InGame = "InGame";
            }
        }
        
        public enum SoundType
        {
            Bgm = 0,
            Se = 1
        }
        
        public static void PrepareAudioSource(this AudioSource source, SoundData soundData)
        {
            source.playOnAwake = soundData.PlayOnAwake;
            source.loop = soundData.IsLoop;
            source.clip = soundData.Clip;
            source.volume = soundData.Volume;
        }
    }
}